namespace Сlustering
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picItems = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumClusters = new System.Windows.Forms.TextBox();
            this.btnMakeClusters = new System.Windows.Forms.Button();
            this.btnMakePoints = new System.Windows.Forms.Button();
            this.txtNumPoints = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.hscrFps = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFps = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.modification = new System.Windows.Forms.Button();
            this.button_quality = new System.Windows.Forms.Button();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.Multi_agent_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_num_clast = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // picItems
            // 
            this.picItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picItems.BackColor = System.Drawing.Color.White;
            this.picItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picItems.Location = new System.Drawing.Point(10, 78);
            this.picItems.Name = "picItems";
            this.picItems.Size = new System.Drawing.Size(1065, 502);
            this.picItems.TabIndex = 0;
            this.picItems.TabStop = false;
            this.picItems.Paint += new System.Windows.Forms.PaintEventHandler(this.picItems_Paint);
            this.picItems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picItems_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(930, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Кластеры:";
            // 
            // txtNumClusters
            // 
            this.txtNumClusters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNumClusters.Location = new System.Drawing.Point(924, 31);
            this.txtNumClusters.Name = "txtNumClusters";
            this.txtNumClusters.Size = new System.Drawing.Size(93, 22);
            this.txtNumClusters.TabIndex = 2;
            this.txtNumClusters.Text = "3";
            this.txtNumClusters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumClusters.TextChanged += new System.EventHandler(this.txtNumClusters_TextChanged);
            // 
            // btnMakeClusters
            // 
            this.btnMakeClusters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMakeClusters.Location = new System.Drawing.Point(376, 30);
            this.btnMakeClusters.Name = "btnMakeClusters";
            this.btnMakeClusters.Size = new System.Drawing.Size(184, 23);
            this.btnMakeClusters.TabIndex = 3;
            this.btnMakeClusters.Text = "К-средних";
            this.btnMakeClusters.UseVisualStyleBackColor = true;
            this.btnMakeClusters.Click += new System.EventHandler(this.btnMakeClusters_Click);
            // 
            // btnMakePoints
            // 
            this.btnMakePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMakePoints.Location = new System.Drawing.Point(12, 31);
            this.btnMakePoints.Name = "btnMakePoints";
            this.btnMakePoints.Size = new System.Drawing.Size(176, 23);
            this.btnMakePoints.TabIndex = 1;
            this.btnMakePoints.Text = "Генерация объектов";
            this.btnMakePoints.UseVisualStyleBackColor = true;
            this.btnMakePoints.Click += new System.EventHandler(this.btnMakePoints_Click);
            // 
            // txtNumPoints
            // 
            this.txtNumPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNumPoints.Location = new System.Drawing.Point(208, 31);
            this.txtNumPoints.Name = "txtNumPoints";
            this.txtNumPoints.Size = new System.Drawing.Size(93, 22);
            this.txtNumPoints.TabIndex = 0;
            this.txtNumPoints.Text = "50";
            this.txtNumPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumPoints.TextChanged += new System.EventHandler(this.txtNumPoints_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(222, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Объекты:";
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 500;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // lblScore
            // 
            this.lblScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblScore.Location = new System.Drawing.Point(12, 611);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(1219, 18);
            this.lblScore.TabIndex = 5;
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.BackColor = System.Drawing.Color.Coral;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.Location = new System.Drawing.Point(48, 586);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Очистка";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // hscrFps
            // 
            this.hscrFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hscrFps.Location = new System.Drawing.Point(966, 586);
            this.hscrFps.Maximum = 209;
            this.hscrFps.Minimum = 1;
            this.hscrFps.Name = "hscrFps";
            this.hscrFps.Size = new System.Drawing.Size(194, 17);
            this.hscrFps.TabIndex = 7;
            this.hscrFps.Value = 20;
            this.hscrFps.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscrFps_Scroll);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(850, 586);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Кадры/сек:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFps
            // 
            this.lblFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFps.Location = new System.Drawing.Point(1187, 586);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(35, 17);
            this.lblFps.TabIndex = 9;
            this.lblFps.Text = "2";
            this.lblFps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(837, 31);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(828, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "порядок p:";
            // 
            // modification
            // 
            this.modification.BackColor = System.Drawing.Color.Orange;
            this.modification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.modification.Location = new System.Drawing.Point(580, 29);
            this.modification.Name = "modification";
            this.modification.Size = new System.Drawing.Size(184, 23);
            this.modification.TabIndex = 13;
            this.modification.Text = "Модификация";
            this.modification.UseVisualStyleBackColor = false;
            this.modification.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_quality
            // 
            this.button_quality.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_quality.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_quality.Location = new System.Drawing.Point(1090, 439);
            this.button_quality.Name = "button_quality";
            this.button_quality.Size = new System.Drawing.Size(141, 28);
            this.button_quality.TabIndex = 14;
            this.button_quality.Text = "оценка качества";
            this.button_quality.UseVisualStyleBackColor = true;
            this.button_quality.Click += new System.EventHandler(this.button_quality_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_result.Location = new System.Drawing.Point(1090, 473);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(141, 22);
            this.textBox_result.TabIndex = 15;
            this.textBox_result.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Multi_agent_btn
            // 
            this.Multi_agent_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Multi_agent_btn.BackColor = System.Drawing.Color.Lime;
            this.Multi_agent_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Multi_agent_btn.Location = new System.Drawing.Point(1083, 20);
            this.Multi_agent_btn.Name = "Multi_agent_btn";
            this.Multi_agent_btn.Size = new System.Drawing.Size(148, 34);
            this.Multi_agent_btn.TabIndex = 16;
            this.Multi_agent_btn.Text = "Мультиагентный";
            this.Multi_agent_btn.UseVisualStyleBackColor = false;
            this.Multi_agent_btn.Click += new System.EventHandler(this.Multi_agent_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(1113, 107);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 22);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "200";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(1113, 177);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(109, 22);
            this.textBox2.TabIndex = 18;
            this.textBox2.Text = "30";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(1113, 246);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(109, 22);
            this.textBox3.TabIndex = 19;
            this.textBox3.Text = "100";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(1126, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "T_max:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(1126, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "N_move:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(1126, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Delta:";
            // 
            // textBox_num_clast
            // 
            this.textBox_num_clast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_num_clast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_num_clast.Location = new System.Drawing.Point(1090, 541);
            this.textBox_num_clast.Name = "textBox_num_clast";
            this.textBox_num_clast.Size = new System.Drawing.Size(109, 22);
            this.textBox_num_clast.TabIndex = 23;
            this.textBox_num_clast.Text = "0";
            this.textBox_num_clast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnMakePoints;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1243, 638);
            this.Controls.Add(this.textBox_num_clast);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Multi_agent_btn);
            this.Controls.Add(this.btnMakeClusters);
            this.Controls.Add(this.modification);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.button_quality);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblFps);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hscrFps);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnMakePoints);
            this.Controls.Add(this.txtNumPoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumClusters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picItems);
            this.Name = "Form1";
            this.Text = "Klaster";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumClusters;
        private System.Windows.Forms.Button btnMakeClusters;
        private System.Windows.Forms.Button btnMakePoints;
        private System.Windows.Forms.TextBox txtNumPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.HScrollBar hscrFps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button modification;
        private System.Windows.Forms.Button button_quality;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Button Multi_agent_btn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_num_clast;
    }
}

