using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

// Вопросы
//1. могут ли агенты пересекаться? больше да чем нет*??
//2. Удалять ли объект, который распространяет агент из ячейки? больше нет чем да
//3. Агент может распространять несколько объектов? больше нет
namespace Сlustering
{
    // 
    class MultiAgent
    {

        public class Obj_Ag // тип объекта
        {
            public List<Obj> objs_lst;            
            public PointF centr = new PointF(0, 0);

            public Obj_Ag()
            {
                objs_lst = new List<Obj>();                
            }
        }
        
        public class Obj // тип объекта
        {
            public int indx;
            public Point_data point;    // данные ячейки            
            public Obj(Point_data point_,int ind)
            {
                point = point_;
                indx = ind;
            }
        }

        public List<PointF> Centroids_M;        
        private Obj_Ag[,] srch_space;
        private int m = 0, n = 0, k = 0, t_max = 0, N_move = 0, delta = 0; // delta - experementn znach      
        private List<(int,int)> ag_list, srch_cells; // список агентов и пространство вокруг ячейки 
        private List<(int,int)>[] obj_list; // мосив со списками дублирующихся объектов
        public List<(Point, Obj)> Agent_obj; // агент с координатами ячейки и объектом

        public MultiAgent(List<Point_data> obj_clast, int t_m, int n_m, int delt) // инициализация пространства поиска
        {
            Agent_obj = new List<(Point, Obj)>();
            Random rnd = new Random();
            List<(int, int)> ag_mas = new List<(int, int)>(); // список свободных ячеек, для инициализации агентов(чтоб случайно добавить их в свободные ячейки)
            ag_list = new List<(int, int)>();
            obj_list = new List<(int, int)>[obj_clast.Count];
            t_max = t_m;
            N_move = n_m;
            delta = delt;

            n = obj_clast.Count;
            m = Convert.ToInt32(Math.Sqrt(4*n));
            k = (int)Math.Round(n / 3.0);
            srch_space = new Obj_Ag[m, m];
            int rd1 = 0, rd2 = 0;


            for (int i = 0; i < m; i++) // вызов конструктора для agent i obj
            {
                for (int j = 0; j < m; j++)
                {
                    srch_space[i, j] = new Obj_Ag();
                }

            }

            for (int i = 0; i < n; i++)
            {
                rd1 = rnd.Next(0, m);
                rd2 = rnd.Next(0, m);
                srch_space[rd1, rd2].objs_lst.Add(new Obj(obj_clast[i],i));
                obj_list[i] = new List<(int, int)>(); // добавление координат в список объектов (необходимо для дублирования)
                obj_list[i].Add((rd1, rd2));

            }
            for (int i = 0; i < m; i++) // добавление пустых ячеек в массив для агента
            {
                for (int j = 0; j < m; j++)
                {
                    if (srch_space[i, j].objs_lst.Count == 0)
                    {
                        ag_mas.Add((i, j));
                    }
                }
            }
            for (int i = 0; i < k; i++)
            {
                rd1 = rnd.Next(0, ag_mas.Count);
                //srch_space[ag_mas[rd1].Item1, ag_mas[rd1].Item2].agent = new Agent();
                Agent_obj.Add((new Point(ag_mas[rd1].Item1, ag_mas[rd1].Item2), null));
                ag_list.Add((ag_mas[rd1].Item1, ag_mas[rd1].Item2));
                ag_mas.RemoveAt(rd1);
                //srch_space[ag_mas[1].Item1, 2].agents_lst.Add();
            }

            srch_cells = new List<(int, int)> { (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1) };// слогаемые для проверки всех соседних ячеек
           
            

        }     
              

        public List<Point_data> MultiClaster()
        {

            Random rnd = new Random();
            int rd1 = 0, rd2 = 0;
            List<(int, int)> ag_mas = new List<(int, int)>();
            // List<Point_data> Points = new List<Point_data>();
            //int t_max = 5, N_move = 3, k = 3; // k - agent.count

            //for (int t = 0; t < t_max; t++)
            //{
            for (int i = 0; i < N_move; i++)
            {
                    for (int j = 0; j < k; j++)
                    {
                        if(Agent_obj[j].Item2 == null)//srch_space[ag_list[j].Item1, ag_list[j].Item2].agent.obj == null) //(до шага 6) если агент не обладает объектом
                        {
                            Check_cells_1(Agent_obj[j].Item1.X, Agent_obj[j].Item1.Y, j); 
                        }
                        if (Agent_obj[j].Item2 != null) // если обладает ( шаг 6)
                        {
                            Check_cells_2(Agent_obj[j].Item1.X, Agent_obj[j].Item1.Y, j);
                        }

                    }
            }
               
            Inf_exchange();
            Selection();

            

            
            for (int i = 0; i < m; i++) // добавление пустых ячеек в массив для агента
            {
                for (int j = 0; j < m; j++)
                {
                    if (srch_space[i, j].objs_lst.Count == 0)
                    {
                        ag_mas.Add((i, j));
                    }
                }
            }
            for (int i = 0; i < k; i++)
            {
                rd1 = rnd.Next(0, ag_mas.Count);
                //srch_space[ag_mas[rd1].Item1, ag_mas[rd1].Item2].agent = new Agent();
                Agent_obj[i] = ((new Point(ag_mas[rd1].Item1, ag_mas[rd1].Item2), null));
                //ag_list.Add((ag_mas[rd1].Item1, ag_mas[rd1].Item2));
                ag_mas.RemoveAt(rd1);
                //srch_space[ag_mas[1].Item1, 2].agents_lst.Add();
            }





            return Calculat_clast_centr();// Union(Calculat_clast_centr()); // расчет окончательный центров кластера
        }
        //****************************************************************************************************************************************
        private void Check_cells_1(int X, int Y, int ag_ind) // проверка ячеек и выбор объекта для распространения
        {
            int x1 = 0, y1 = 0, r = 0;
            Random rand = new Random();
            int k1 = 0;
            List<int> check = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            for (int i = 0; i < check.Count;) // ячейки рассматриваются по кругу 
            {
                k1 = check[rand.Next(0, check.Count)];
                check.Remove(k1);
                x1 = X + srch_cells[k1].Item1;
                y1 = Y + srch_cells[k1].Item2;
                if (x1 >= 0 && x1 < m && y1 < m && y1 >= 0 && srch_space[x1, y1].objs_lst.Count > 0 && !If_Ag_in_Cell(x1,y1))//проверка выхода за границу
                {
                    
                    //if (srch_space[x1, y1].objs_lst.Count > 0 && srch_space[x1, y1].agent == null) //нет ли агентов и есть ли объекты
                   // {
                    if (srch_space[x1, y1].objs_lst.Count == 1) // если в ячейке один объект                        
                    {                        
                        Agent_obj[ag_ind] = (new Point(x1, y1), new Obj(srch_space[x1, y1].objs_lst[0].point, srch_space[x1, y1].objs_lst[0].indx));
                        
                            return;
                       
                    }                        
                    else if (srch_space[x1, y1].objs_lst.Count == 2) // случайный из двух                        
                    {                          
                        r = rand.Next(0, 2);
                        Agent_obj[ag_ind] = (new Point(x1, y1), new Obj(srch_space[x1, y1].objs_lst[r].point, srch_space[x1, y1].objs_lst[r].indx));
                                              
                        return;
                        
                    }                       
                    else // выбор худшего                        
                    {                           
                        int ind = Worst_obj_ind(srch_space[x1, y1].objs_lst);                          
                        Agent_obj[ag_ind] = (new Point(x1, y1), new Obj(srch_space[x1, y1].objs_lst[ind].point, srch_space[x1, y1].objs_lst[ind].indx));
                                                  
                        return;                        
                    }

                    //}

                }
            }
            check = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            for (int i = 0; i < check.Count;) // ячейки рассматриваются по кругу 
            {
                k1 = check[rand.Next(0, check.Count)];
                check.Remove(k1);
                x1 = X + srch_cells[k1].Item1;
                y1 = Y + srch_cells[k1].Item2;
                if (x1 >= 0 && x1 < m && y1 < m && y1 >= 0)//проверка выхода за границу
                {
                    Agent_obj[ag_ind] = (new Point(x1, y1), null);
                    

                }
            }
        }

        private bool If_Ag_in_Cell(int x1, int y1)
        {
            for (int i = 0; i < Agent_obj.Count; i++)
            {
                if (Agent_obj[i].Item1.X == x1 && Agent_obj[i].Item1.Y == y1)
                    return true;
            }
            return false;
        }
        //****************************************************************************************************************************************
        private void Check_cells_2(int X, int Y, int ag_ind) // проверка ячеек и выбор объекта для распространения
        {
            int x1 = 0, y1 = 0;//, it1 = 0, it2 =0;
            int k1 = 0;
            List<Obj> tmp_list = new List<Obj>();
            Random rand = new Random();
            List<Obj> tmp_Obj = new List<Obj>();
            List<int> check = new List<int>() { 0,1,2,3,4,5,6,7};
            for (int i = 0; i < check.Count;) // ячейки рассматриваются по кругу 
            {
                k1 = check[rand.Next(0, check.Count)];
                check.Remove(k1);//At(check.IndexOf(check[k]));

                x1 = X + srch_cells[k1].Item1;
                y1 = Y + srch_cells[k1].Item2;
                if (x1 >= 0 && x1 < m && y1 < m && y1 >= 0)//проверка выхода за границу
                {  // Проверить!!!                                 

                    //if (!obj_list[srch_space[X, Y].agent.obj.indx].Contains((x1, y1))) //!srch_space[x1, y1].objs_lst.Contains(srch_space[X, Y].agent.obj) есть ли такой объект в данной ячейке
                    if (!In_Cell(x1, y1, ag_ind))
                    {                   
                        
                        if (srch_space[x1, y1].objs_lst.Count > 0 && !If_Ag_in_Cell(x1,y1)) //нет ли агентов и есть ли объекты  && srch_space[x1, y1].objs_lst[0]                    
                        {                        
                            if (srch_space[x1, y1].objs_lst.Count == 1  && rand.Next(0,100) >=50 ) // если в ячейке один объект, то с вероятн 0.5 дублируется                   
                            {                               
                                    srch_space[x1, y1].objs_lst.Add(Agent_obj[ag_ind].Item2);                                    
                                    obj_list[Agent_obj[ag_ind].Item2.indx].Add((x1, y1)); // проверить                                   
                                                           
                            }                        
                            else if(srch_space[x1, y1].objs_lst.Count > 1)                   
                            {
                                tmp_Obj.Add(Agent_obj[ag_ind].Item2); 
                                tmp_Obj.AddRange(srch_space[x1, y1].objs_lst); // cписок объектов в ячейке объекта
                                if (Worst_obj_value(tmp_Obj) > Worst_obj_value_ind(srch_space[obj_list[Agent_obj[ag_ind].Item2.indx][0].Item1, obj_list[Agent_obj[ag_ind].Item2.indx][0].Item2].objs_lst , Search_ind_Obj(Agent_obj[ag_ind].Item2.indx, 0))
                                    && srch_space[obj_list[Agent_obj[ag_ind].Item2.indx][0].Item1, obj_list[Agent_obj[ag_ind].Item2.indx][0].Item2].objs_lst.Count > 1)// Worst_obj_value_ind(tmp_Obj, 0)) //////////
                                {
                                    //int ind wh;
                                    Agent_obj[ag_ind] = (new Point(x1, y1), new Obj(tmp_Obj[Worst_obj_ind(tmp_Obj)].point, tmp_Obj[Worst_obj_ind(tmp_Obj)].indx)); //
                                    return;
                                }
                                                               

                                else if(Worst_obj_value_ind(tmp_Obj, 0) <
                                    Worst_obj_value_ind(srch_space[obj_list[Agent_obj[ag_ind].Item2.indx][0].Item1, obj_list[Agent_obj[ag_ind].Item2.indx][0].Item2].objs_lst,
                                    Ind_in_Cell(srch_space[obj_list[Agent_obj[ag_ind].Item2.indx][0].Item1, obj_list[Agent_obj[ag_ind].Item2.indx][0].Item2].objs_lst, Agent_obj[ag_ind].Item2))  )//Worst_obj_value_ind(srch_space[obj_list[Agent_obj[ag_ind].Item2.indx][0].Item1, obj_list[Agent_obj[ag_ind].Item2.indx][0].Item2].objs_lst, W))
                                {
                                   // Ind_in_Cell(srch_space[obj_list[Agent_obj[ag_ind].Item2.indx][0].Item1, obj_list[Agent_obj[ag_ind].Item2.indx][0].Item2].objs_lst, Agent_obj[ag_ind].Item2)
                                    //if (!In_Cell(x1, y1, ag_ind)) { 
                                     srch_space[x1, y1].objs_lst.Add(Agent_obj[ag_ind].Item2);
                                     obj_list[Agent_obj[ag_ind].Item2.indx].Add((x1, y1));
                                     Agent_obj[ag_ind] = (new Point(x1, y1), new Obj(Agent_obj[ag_ind].Item2.point, Agent_obj[ag_ind].Item2.indx));
                                    //obj_list[Agent_obj[ag_ind].Item2.indx].Add((x1, y1));
                                     return;
                                    //}
                                }                             
                                
                                //  условия  в расматриваемой ячейке лучше, чем в исходной ( не ясно как оценивать??)
                                
                            }
                    
                        }

                    }
                }
            }           

            check = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            for (int i = 0; i < check.Count;) // ячейки рассматриваются по кругу 
            {
                k1 = check[rand.Next(0, check.Count)];
                check.Remove(k1);
                //int j = rand.Next(0, 8);
                x1 = X + srch_cells[k1].Item1;
                y1 = Y + srch_cells[k1].Item2;
                if (x1 >= 0 && x1 < m && y1 < m && y1 >= 0)//проверка выхода за границу
                {

                    Agent_obj[ag_ind] = (new Point(x1, y1), new Obj(Agent_obj[ag_ind].Item2.point, Agent_obj[ag_ind].Item2.indx));                   
                    return;                 

                }
            }

        }
        private int Ind_in_Cell(List<Obj> objs, Obj obj)
        {
            for (int i = 0; i < objs.Count; i++)
            {
                if(obj.indx == objs[i].indx)
                {
                    return i;
                }
            }
            return -1;
        }


        private bool In_Cell(int x1, int y1, int ag_ind)
        {
            for (int i = 0; i < srch_space[x1, y1].objs_lst.Count; i++)
            {
                if (srch_space[x1, y1].objs_lst[i].indx == Agent_obj[ag_ind].Item2.indx)
                    return true;
            }
            
            return false;
            
        }

        

        private int Worst_obj_ind(List<Obj> objs) // поиск худшего объекта
        {
            
            Point_data cntr = new Point_data(0, 0, 0), sum_obj = new Point_data(0, 0, 0);
            List<double> worst = new List<double>();
            

            for (int i = 0; i < objs.Count; i++)// вычисление центра
            {
                sum_obj.Location.X += objs[i].point.Location.X;
                sum_obj.Location.Y += objs[i].point.Location.Y;
            }
            cntr.Location.X = sum_obj.Location.X / objs.Count;
            cntr.Location.Y = sum_obj.Location.Y / objs.Count;

            for (int i = 0; i < objs.Count; i++) //добавление всех расстояний
            {
                worst.Add(
                Math.Pow(Math.Pow(Math.Abs(cntr.Location.X - objs[i].point.Location.X), 2) +
                    Math.Pow(Math.Abs(cntr.Location.Y - objs[i].point.Location.Y), 2), 1.0 / 2));
            }
            //Math.Pow(Math.Pow(Math.Abs(point1.X - point2.X), 2) + Math.Pow(Math.Abs(point1.Y - point2.Y), 2), 1.0 / 2);
            return worst.IndexOf(worst.Max());
        }

        private double Worst_obj_value(List<Obj> objs) // поиск худшего объекта
        {
            if (objs.Count == 1)
                return  int.MaxValue;
            Point_data cntr = new Point_data(0, 0, 0), sum_obj = new Point_data(0, 0, 0);
            List<double> worst = new List<double>();


            for (int i = 0; i < objs.Count; i++)// вычисление центра
            {
                sum_obj.Location.X += objs[i].point.Location.X;
                sum_obj.Location.Y += objs[i].point.Location.Y;
            }
            cntr.Location.X = sum_obj.Location.X / objs.Count;
            cntr.Location.Y = sum_obj.Location.Y / objs.Count;

            for (int i = 0; i < objs.Count; i++) //добавление всех расстояний
            {
                worst.Add(
                Math.Pow(Math.Pow(Math.Abs(cntr.Location.X - objs[i].point.Location.X), 2) +
                    Math.Pow(Math.Abs(cntr.Location.Y - objs[i].point.Location.Y), 2), 1.0 / 2));
            }
            //Math.Pow(Math.Pow(Math.Abs(point1.X - point2.X), 2) + Math.Pow(Math.Abs(point1.Y - point2.Y), 2), 1.0 / 2);
            return worst.Max();
        }
        private double Worst_obj_value_ind(List<Obj> objs,int ind) // поиск расстояния по индексу из ячейки
        {
            if (objs.Count == 1)
                return  int.MaxValue;
            Point_data cntr = new Point_data(0, 0, 0), sum_obj = new Point_data(0, 0, 0);
            List<double> worst = new List<double>();


            for (int i = 0; i < objs.Count; i++)// вычисление центра
            {
                sum_obj.Location.X += objs[i].point.Location.X;
                sum_obj.Location.Y += objs[i].point.Location.Y;
            }
            cntr.Location.X = sum_obj.Location.X / objs.Count;
            cntr.Location.Y = sum_obj.Location.Y / objs.Count;

            for (int i = 0; i < objs.Count; i++) //добавление всех расстояний
            {
                worst.Add(
                Math.Pow(Math.Pow(Math.Abs(cntr.Location.X - objs[i].point.Location.X), 2) +
                    Math.Pow(Math.Abs(cntr.Location.Y - objs[i].point.Location.Y), 2), 1.0 / 2));
            }
            //Math.Pow(Math.Pow(Math.Abs(point1.X - point2.X), 2) + Math.Pow(Math.Abs(point1.Y - point2.Y), 2), 1.0 / 2);
            return worst[ind];
        }
        private void Inf_exchange() // обмен информацией между агентами
        {
            Random rnd = new Random();
            List<(Point,Obj)> tmp_1 = new List<(Point, Obj)>(), tmp_2 = new List<(Point, Obj)>();
            List<(Point, Obj)> inf_ag = new List<(Point, Obj)>(), analiz_ag = new List<(Point, Obj)>();//, other = new List<Agent>();
            int ind_cell = 0, it1 = 0, it2 = 0;
            int ind_inf_ag = 0;
            for (int i = 0; i < Agent_obj.Count; i++)//распределение по группам
            {
                if(Agent_obj[i].Item2 != null) // если есть объект распространения
                {
                    ind_cell = Agent_obj[i].Item2.indx; // индекс ячейки с объектом
                    it1 = obj_list[ind_cell][0].Item1;
                    it2 = obj_list[ind_cell][0].Item2;
                    if (srch_space[it1, it2].objs_lst.Count > 2 && Worst_obj_value_ind(srch_space[it1, it2].objs_lst, Search_ind_Obj(ind_cell, 0)) < delta)// у объекта в исходной ячейке 3 и более объектов , его расстояние от центра < delta
                    {
                        tmp_1.Add(Agent_obj[i]);
                    }
                    else if (srch_space[it1, it2].objs_lst.Count == 1)// объект агента в исходной ячейке единств
                    {
                        tmp_2.Add(Agent_obj[i]);
                    }
                    else // первые два не подходят
                    {
                        //if (srch_space[it1, it2].objs_lst.Count == 0)
                        //{
                        //    return;
                        //}
                        analiz_ag.Add(Agent_obj[i]);
                    }
                }
                
            }
            for (int i = 0; i < tmp_1.Count; i++) // половина информир, и пол-на остальным
            {
                if(rnd.Next(0,100) > 49)
                    inf_ag.Add(tmp_1[i]);
                else
                    analiz_ag.Add(tmp_1[i]);              
                
            }
            for (int i = 0; i < tmp_2.Count; i++)// половина анализир, и пол-на остальным
            {
                if (rnd.Next(0, 100) > 49)
                    inf_ag.Add(tmp_2[i]);
                else
                    analiz_ag.Add(tmp_2[i]);
            }
            if (analiz_ag.Count > 0 && inf_ag.Count > 0)
            {
                for (int i = 0; i < analiz_ag.Count; i++)//расчет и дублирование (проверка на повторение в ячейке)**
                {
                    ind_inf_ag = Index_Inf_ag(inf_ag, analiz_ag[i]);
                    if (ind_inf_ag > 0)
                    {
                        for (int l = 0; l < obj_list[inf_ag[ind_inf_ag].Item2.indx].Count; l++)
                        {
                            it1 = obj_list[inf_ag[ind_inf_ag].Item2.indx][0].Item1;
                            it2 = obj_list[inf_ag[ind_inf_ag].Item2.indx][0].Item2;

                            if (!srch_space[it1, it2].objs_lst.Contains( analiz_ag[i].Item2))
                            {
                                srch_space[it1, it2].objs_lst.Add(analiz_ag[i].Item2);
                                obj_list[analiz_ag[i].Item2.indx].Add((it1, it2));
                            }
                            srch_space[it1, it2].objs_lst.Add(analiz_ag[i].Item2);
                            obj_list[analiz_ag[i].Item2.indx].Add((it1, it2));

                        }


                        //}
                    }
                }
            }
            
            
        }
        private int Index_Inf_ag(List<(Point, Obj)> agents, (Point, Obj) ag_analiz)
        {
            //int l = 0;
            List<double> dist = new List<double>();
            for (int i = 0; i < agents.Count; i++)
            {
                dist.Add(Dist(agents[i], ag_analiz));
            }
            if (dist.Min() < delta && dist.Min()>0)
                return dist.IndexOf(dist.Min());
            else
                return -1;
        }
        private double Dist((Point, Obj) inf, (Point, Obj) analiz)
        {
            return Math.Pow(Math.Pow(Math.Abs(inf.Item2.point.Location.X - analiz.Item2.point.Location.X), 2) +
                    Math.Pow(Math.Abs(inf.Item2.point.Location.Y - analiz.Item2.point.Location.Y), 2), 1.0 / 2);            
        }

        private void Selection() // естественный отбор одного объекта из всех продублированных
        {
            List<double> tmp_lst = new List<double>();
            int  it1 = 0, it2 = 0, ind_min; //ind_obj_list = 0,
            (int, int) tmp_obj = (0, 0);

            for (int i = 0; i < obj_list.Length; i++)
            {
                if (obj_list[i].Count > 1)
                {
                    for (int j = 0; j < obj_list[i].Count; j++)
                    {
                        it1 = obj_list[i][j].Item1; // индекс ячейки в которой искомый объект
                        it2 = obj_list[i][j].Item2;                        

                        tmp_lst.Add(Worst_obj_value_ind(srch_space[it1, it2].objs_lst, Search_ind_Obj(i, j))); // список растояний от центров до объектов
                        
                    }
                    ind_min = tmp_lst.IndexOf(tmp_lst.Min()); // находим индекс списка, ячейка которого остается
                    
                    tmp_obj = obj_list[i][ind_min];
                    for (int j = 0; j < obj_list[i].Count; j++)
                    {
                        it1 = obj_list[i][j].Item1; // индекс ячейки в которой искомый объект
                        it2 = obj_list[i][j].Item2;
                        if (j != ind_min)
                        {
                            srch_space[it1, it2].objs_lst.RemoveAt(Search_ind_Obj(i, j));

                            //obj_list[i].RemoveAt(j);
                        }
                        
                    }
                    obj_list[i].Clear();
                    obj_list[i].Add(tmp_obj);
                    tmp_lst.Clear();
                }
                
            }
            
        }

        

        private int Search_ind_Obj(int ind_obj, int num_obj)//поиск индекса искомого объекта в ячейке
        {
            int it1 = 0, it2 = 0;
            it1 = obj_list[ind_obj][num_obj].Item1; // индекс ячейки в которой искомый объект
            it2 = obj_list[ind_obj][num_obj].Item2;
            for (int k = 0; k < srch_space[it1, it2].objs_lst.Count; k++) 
                if (srch_space[it1, it2].objs_lst[k].indx == ind_obj)
                    return k;
            return -1;
        }

        private List<Point_data> Calculat_clast_centr()  // по формуле центров масс?
        {
            List<Point_data> points = new List<Point_data>();
            Centroids_M = new List<PointF>();
            int num_clast = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (srch_space[i, j].objs_lst.Count > 0) 
                    {                     
                        srch_space[i, j].centr = Centr_Cell(srch_space[i, j].objs_lst);
                        Centroids_M.Add(srch_space[i, j].centr);

                        for (int c = 0; c < srch_space[i, j].objs_lst.Count; c++)// расчет центров по каждой ячейке
                        {
                            srch_space[i, j].objs_lst[c].point.ClusterNum = num_clast;
                            points.Add(srch_space[i, j].objs_lst[c].point);
                        }
                        num_clast++;
                    }
                }
            }


            //List<double> lst_centrs = new List<double>();
            return points;
        }

        private PointF Centr_Cell(List<Obj> objs) // поиск худшего объекта
        {

            Point_data cntr = new Point_data(0, 0, 0), sum_obj = new Point_data(0, 0, 0);
            List<double> worst = new List<double>();


            for (int i = 0; i < objs.Count; i++)// вычисление центра
            {
                sum_obj.Location.X += objs[i].point.Location.X;
                sum_obj.Location.Y += objs[i].point.Location.Y;
            }
            cntr.Location.X = sum_obj.Location.X / objs.Count;
            cntr.Location.Y = sum_obj.Location.Y / objs.Count;

           
            return new PointF(cntr.Location.X, cntr.Location.Y);
        }



        public List<Point_data> Union() // объеденение ячеек
        {
            //for (int l = 0; l < Centroids_M.Count; l++)
            //{
                int unit_cell = 0;
                if (Centroids_M.Count > 1)
                {
                    for (int i = 0; i < Centroids_M.Count; )
                    {
                        unit_cell = Min_dist(Centroids_M[i], i);
                        if (unit_cell >= 0)
                        {
                            Unit_Cells(i, unit_cell); // 0   0
                            Calculat_clast_centr();
                        }
                        else
                            i++;
                    }
                }

            //}

            return Calculat_clast_centr(); 
        }

        private void Unit_Cells( int u_cell, int ind) // 0    0
        {
            (int, int) cell_1 = (0, 0), cell_2 = (0, 0);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if(srch_space[i,j].centr == Centroids_M[u_cell])
                    {
                        cell_1 = (i, j);
                            break;
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (srch_space[i, j].centr == Centroids_M[ind])
                    {
                        cell_2 = (i, j);
                        break;
                    }

                }
            }
            //for (int i = 0; i < srch_space[cell_2.Item1, cell_2.Item2].objs_lst.Count; i++)
            //{
            srch_space[cell_1.Item1, cell_1.Item2].objs_lst.AddRange(srch_space[cell_2.Item1, cell_2.Item2].objs_lst);
            srch_space[cell_2.Item1, cell_2.Item2].objs_lst.Clear();
            srch_space[cell_2.Item1, cell_2.Item2].centr = srch_space[cell_1.Item1, cell_1.Item2].centr;
            Centroids_M.Remove(Centroids_M[u_cell]);

                        
        }

        private int Min_dist(PointF centr, int ind)
        {
            List<double> min_dist = new List<double>();
            for (int i = 0; i < Centroids_M.Count; i++)
            {
                if (i != ind)
                    min_dist.Add(Dist_Centrs(centr, Centroids_M[i]));        ///////**
                else min_dist.Add(10000000.2);

            }
            if(min_dist.Min() < delta )
            {
                return min_dist.IndexOf(min_dist.Min());
            }
            return -1;
        }

        private double Dist_Centrs(PointF cntr1, PointF cntr2)
        {
            return  Math.Pow(Math.Pow(Math.Abs(cntr1.X - cntr2.X), 2) +
                    Math.Pow(Math.Abs(cntr1.Y - cntr2.Y), 2), 1.0 / 2);
        }
    }
}

