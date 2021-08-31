using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace Сlustering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<PointF> Seeds = new List<PointF>();
        private List<PointF> Centroids = new List<PointF>();
        private List<Point_data> Points = new List<Point_data>();
        private int NumSteps = 0;
        private bool mod = false;
        MultiAgent a;
        //MultiAgent a = new MultiAgent(6); // запуск мультиагентного метода ..


        private Brush[] PointBrushes =
        {
            Brushes.Pink, Brushes.LightGreen, Brushes.LightBlue, Brushes.Yellow,
            Brushes.Orange, Brushes.Lime, Brushes.Cyan, Brushes.White,
        };
        private Pen[] PointPens =
        {
            Pens.Red, Pens.Green, Pens.Blue, Pens.Black,
            Pens.Red, Pens.Green, Pens.Blue, Pens.Black,
        };
        private Brush[] CentroidBrushes =
        {
            Brushes.Red, Brushes.Green, Brushes.Blue, Brushes.Yellow,
            Brushes.Orange, Brushes.Lime, Brushes.Cyan, Brushes.White,
        };

        private int MaxClusters = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            MaxClusters = PointBrushes.Length;
        }

        private void picItems_Paint(object sender, PaintEventArgs e)
        {
            const float RADIUS = 4;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //Отрисовка точек.
            foreach (Point_data point_data in Points)
            {
                e.Graphics.DrawPoint(point_data.Location,
                    PointBrushes[point_data.ClusterNum % MaxClusters],
                    PointPens[point_data.ClusterNum % MaxClusters], RADIUS);
            }

            // отрисовка центроидов.
            for (int i = 0; i < Centroids.Count; i++)
            {
                e.Graphics.DrawRect(Centroids[i],
                    CentroidBrushes[i % MaxClusters], Pens.Black, RADIUS);
            }

            // Отрисовка точек генерации.
            for (int i = 0; i < Seeds.Count; i++)
            {
                e.Graphics.DrawCross(Color.Black, Color.White,
                    Seeds[i], 2 * RADIUS);
            }
        }

        // создание объектов вокруг точек генерации.
        private void btnMakePoints_Click(object sender, EventArgs e)
        {
            MakePoints();
        }

        private void MakePoints()
        {
            // 
            if (Seeds.Count < 1)
            {
                MessageBox.Show("Необходимо выбрать точку генерации");
                return;
            }

            // 
            Centroids.Clear();

            // .
            Random rand = new Random();
            double max_r = Math.Min(
                picItems.ClientSize.Width,
                picItems.ClientSize.Height) / 10;
            int num_points = int.Parse(txtNumPoints.Text);
            for (int i = 0; i < num_points; i++)
            {
                int seed_num = rand.Next(Seeds.Count);
                double r =
                    max_r * rand.NextDouble() +
                    max_r * rand.NextDouble();
                double theta = rand.Next(360);
                float x = Seeds[seed_num].X + (float)(r * Math.Cos(theta));
                float y = Seeds[seed_num].Y + (float)(r * Math.Sin(theta));
                Points.Add(new Point_data(x, y, 0));
            }

            picItems.Refresh();
        }

        
        private double Distance(PointF point1, PointF point2)    //расстояние по формуле минковского
        {
            double p = (int)numericUpDown1.Value;//

            return Math.Pow(Math.Pow(Math.Abs(point1.X - point2.X), p) + Math.Pow(Math.Abs(point1.Y - point2.Y), p), 1.0 / p);
        }

        private void UpdateSolution()
        {
            //try
            //{
                // Поиск новых центройдов.
                double big_centr = 0;
                int num_clusters = Centroids.Count;
                PointF[] new_centers = new PointF[num_clusters];
                int[] num_points = new int[num_clusters];
                foreach (Point_data point in Points)
                {
                    double best_dist =
                        Distance(point.Location, Centroids[0]);
                    int best_cluster = 0;
                    for (int i = 1; i < num_clusters; i++)
                    {
                        double test_dist =
                            Distance(point.Location, Centroids[i]);
                        if (test_dist < best_dist)
                        {
                            best_dist = test_dist;
                            best_cluster = i;
                        }
                    }
                    point.ClusterNum = best_cluster;
                    new_centers[best_cluster].X += point.Location.X;
                    new_centers[best_cluster].Y += point.Location.Y;
                    num_points[best_cluster]++;
                }

                // Вычисление новых центройдов.
                List<PointF> new_centroids = new List<PointF>();
                for (int i = 0; i < num_clusters; i++)
                {
                    new_centroids.Add(new PointF(
                        new_centers[i].X / num_points[i],
                        new_centers[i].Y / num_points[i]));
                }

                // Смотрим, не сдвинулись ли центроиды.
                bool centroids_changed = false;
                for (int i = 0; i < num_clusters; i++)
                {
                    const float min_change = 0.5f; // погрешность сдвига
                    if ((Math.Abs(Centroids[i].X - new_centroids[i].X) > min_change) ||
                        (Math.Abs(Centroids[i].Y - new_centroids[i].Y) > min_change))
                    {
                        centroids_changed = true;
                        break;
                    }
                }

                /////////////////////////////////////////////////////////////////
                if (Convert.ToInt32(txtNumClusters.Text) > num_clusters && !centroids_changed && mod) //dobavlenie
                {
                    int big_num = 0;
                    for (int i = 0; i < Points.Count; i++)//sum coordinat centroid
                    {
                        if (Distance(Points[i].Location, Centroids[Points[i].ClusterNum]) > big_centr)
                        {
                            big_centr = Distance(Points[i].Location, Centroids[Points[i].ClusterNum]);
                            big_num = i;
                        }
                    }
                    //Add_Centroid(Centroids[Points[big_num].ClusterNum], Points[big_num].Location);
                    PointF A = Centroids[Points[big_num].ClusterNum], B = Points[big_num].Location;
                    PointF pf = new PointF((A.X + B.X) / 2, (A.Y + B.Y) / 2);

                    Centroids.Add(pf);
                    new_centroids = Centroids;

                }
                ///////////////////////////////////////////////////////////////

                else if (!centroids_changed)
                {
                    tmrUpdate.Enabled = false;  //завершение выполнения алгоритма
                                                //System.Media.SystemSounds.Beep.Play();   //время выполнения?
                    lblScore.Text =// "Score: " + Score().ToString() +
                                   //", " +
                        "# Шаги: " + NumSteps.ToString();
                    Cursor = Cursors.Default;
                    //Cursor.Show();
                    return;
                }

                // Update the centroids.
                Centroids = new_centroids;
            //}
            //catch
            //{
                
            //}
        }

        private void btnMakeClusters_Click(object sender, EventArgs e)
        {
            //Cursor.Hide();
            //Cursor = n
            mod = false;
            int num_clusters = int.Parse(txtNumClusters.Text);
            if (Points.Count < num_clusters) return;

            // Сбросить данные. 
            // Выбор случайных центроидов. 
            Centroids = new List<PointF>();
            Points.Randomize();
            for (int i = 0; i < num_clusters; i++)
                Centroids.Add(Points[i].Location);
            foreach (Point_data point_data in Points)
                point_data.ClusterNum = 0;

            NumSteps = 0;
            picItems.Refresh();
            lblScore.Text = "";
            Cursor = Cursors.WaitCursor;
            tmrUpdate.Enabled = true;
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                NumSteps++;
                UpdateSolution();
                picItems.Refresh();
            }
            catch
            {
                tmrUpdate.Enabled = false;
                Cursor = Cursors.Default;
                //picItems.Refresh();
                MessageBox.Show("кластеризация не завершена");
                
            }
        }

        private int Score()
        {
            float score = 0;
            foreach (Point_data point in Points)
            {
                float dx = Centroids[point.ClusterNum].X - point.Location.X;
                float dy = Centroids[point.ClusterNum].Y - point.Location.Y;
                score += dx * dx + dy * dy;
            }
            return (int)score;
        }

        private void picItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Seeds.Add(e.Location);
            else
                Points.Add(new Point_data(e.Location, 0));
            Centroids.Clear();
            picItems.Refresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Seeds.Clear();
            Centroids.Clear();
            Points.Clear();

            picItems.Refresh();
        }

        private void hscrFps_Scroll(object sender, ScrollEventArgs e)
        {
            // Divide by 10 so speed is between 1 and 20.
            int fps = hscrFps.Value / 10;
            if (fps < 1) fps = 1;
            lblFps.Text = fps.ToString();
            tmrUpdate.Interval = 1000 / fps;
        }

        private void button1_Click(object sender, EventArgs e)  // запуск модификации
        {
            mod = true;
            int num_clusters = int.Parse(txtNumClusters.Text);
            if (Points.Count < num_clusters) return;

            // Сбросить данные. 
            // Выбор случайных центроидов. 
            Centroids = new List<PointF>();
            Points.Randomize();
            //for (int i = 0; i < num_clusters; i++)
            for (int i = 0; i < 1; i++)
                Centroids.Add(Points[i].Location);
            foreach (Point_data point_data in Points)
                point_data.ClusterNum = 0;

            NumSteps = 0;
            picItems.Refresh();
            lblScore.Text = "";
            Cursor = Cursors.WaitCursor;
            tmrUpdate.Enabled = true;
        }

        private void button_quality_Click(object sender, EventArgs e)
        {
            double result = 0.0;
            try
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    result += Distance(Points[i].Location, Centroids[Points[i].ClusterNum]);
                }
                textBox_result.Text = Convert.ToString(Math.Round(result, 2));
            }
            catch
            {
                MessageBox.Show("нет данных кластеризации");
            }
        }

        private void Multi_agent_btn_Click(object sender, EventArgs e)
        {
           
            //picItems.Refresh();

            try
            {
                 a = new MultiAgent(Points, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                picItems.Refresh();
                Cursor = Cursors.WaitCursor;
                tmrUpdate.Enabled = true;
                for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                {
                    Points = a.MultiClaster();
                    Centroids = a.Centroids_M;
                    //textBox_num_clast.Text = Centroids.Count.ToString();
                    picItems.Refresh();
                }
                tmrUpdate.Enabled = false;
                Cursor = Cursors.Default;

                Points = a.Union();
                Centroids = a.Centroids_M;
                textBox_num_clast.Text = Centroids.Count.ToString();



                picItems.Refresh();
                button_quality_Click(sender, e);
            //picItems.Show();
            }
            catch
            {
                MessageBox.Show("нет данных кластеризации");
            }
    }

        private void button1_Click_1(object sender, EventArgs e)
        {

           


            
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { 
            if (Convert.ToInt32(textBox1.Text) < 1)
                {
                    MessageBox.Show("число должно быть положительным");
                    textBox1.Text = "200";
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox1.Text = "200";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox2.Text) < 1)
                {
                    MessageBox.Show("число должно быть положительным");
                    textBox2.Text = "30";
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox2.Text = "30";
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox3.Text) < 1)
                {
                    MessageBox.Show("число должно быть положительным");
                    textBox3.Text = "100";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox3.Text = "100";
            }
        }

        private void txtNumClusters_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtNumClusters.Text) < 1)
                {
                    MessageBox.Show("число должно быть положительным");
                    txtNumClusters.Text = "3";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtNumClusters.Text = "3";
            }
        }

        private void txtNumPoints_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtNumPoints.Text) < 1)
                {
                    MessageBox.Show("число должно быть положительным");
                    txtNumPoints.Text = "50";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtNumPoints.Text = "50";
            }
        }
    }
}

