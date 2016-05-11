namespace PresentationForms
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tBoxX1Left = new System.Windows.Forms.TextBox();
            this.tBoxX1Right = new System.Windows.Forms.TextBox();
            this.tBoxX2Left = new System.Windows.Forms.TextBox();
            this.tBoxX2Right = new System.Windows.Forms.TextBox();
            this.tBoxN = new System.Windows.Forms.TextBox();
            this.tBoxExeEnd = new System.Windows.Forms.TextBox();
            this.tBoxPercent = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tBoxAccuracy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBoxMutation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bOneStep = new System.Windows.Forms.Button();
            this.bToEnd = new System.Windows.Forms.Button();
            this.bInitialize = new System.Windows.Forms.Button();
            this.tBoxFormula = new System.Windows.Forms.TextBox();
            this.bChangeGA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tBoxX1Left
            // 
            this.tBoxX1Left.Location = new System.Drawing.Point(524, 11);
            this.tBoxX1Left.Name = "tBoxX1Left";
            this.tBoxX1Left.Size = new System.Drawing.Size(100, 20);
            this.tBoxX1Left.TabIndex = 0;
            this.tBoxX1Left.Text = "-10";
            // 
            // tBoxX1Right
            // 
            this.tBoxX1Right.Location = new System.Drawing.Point(694, 11);
            this.tBoxX1Right.Name = "tBoxX1Right";
            this.tBoxX1Right.Size = new System.Drawing.Size(100, 20);
            this.tBoxX1Right.TabIndex = 1;
            this.tBoxX1Right.Text = "10";
            // 
            // tBoxX2Left
            // 
            this.tBoxX2Left.Location = new System.Drawing.Point(524, 38);
            this.tBoxX2Left.Name = "tBoxX2Left";
            this.tBoxX2Left.Size = new System.Drawing.Size(100, 20);
            this.tBoxX2Left.TabIndex = 3;
            this.tBoxX2Left.Text = "-5";
            // 
            // tBoxX2Right
            // 
            this.tBoxX2Right.Location = new System.Drawing.Point(694, 37);
            this.tBoxX2Right.Name = "tBoxX2Right";
            this.tBoxX2Right.Size = new System.Drawing.Size(100, 20);
            this.tBoxX2Right.TabIndex = 4;
            this.tBoxX2Right.Text = "5";
            // 
            // tBoxN
            // 
            this.tBoxN.Location = new System.Drawing.Point(694, 63);
            this.tBoxN.Name = "tBoxN";
            this.tBoxN.Size = new System.Drawing.Size(100, 20);
            this.tBoxN.TabIndex = 5;
            this.tBoxN.Text = "20";
            // 
            // tBoxExeEnd
            // 
            this.tBoxExeEnd.Location = new System.Drawing.Point(694, 115);
            this.tBoxExeEnd.Name = "tBoxExeEnd";
            this.tBoxExeEnd.Size = new System.Drawing.Size(100, 20);
            this.tBoxExeEnd.TabIndex = 6;
            this.tBoxExeEnd.Text = "10";
            // 
            // tBoxPercent
            // 
            this.tBoxPercent.Location = new System.Drawing.Point(694, 90);
            this.tBoxPercent.Name = "tBoxPercent";
            this.tBoxPercent.Size = new System.Drawing.Size(100, 20);
            this.tBoxPercent.TabIndex = 7;
            this.tBoxPercent.Text = "80";
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(12, 13);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(306, 435);
            this.chart.TabIndex = 8;
            this.chart.Text = "chart1";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(345, 175);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(449, 273);
            this.dataGridView.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(631, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "<= X <=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(631, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "<= Y <=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(631, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "N";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(631, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "n %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(631, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "End";
            // 
            // tBoxAccuracy
            // 
            this.tBoxAccuracy.Location = new System.Drawing.Point(524, 64);
            this.tBoxAccuracy.Name = "tBoxAccuracy";
            this.tBoxAccuracy.Size = new System.Drawing.Size(100, 20);
            this.tBoxAccuracy.TabIndex = 15;
            this.tBoxAccuracy.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(464, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Accuracy";
            // 
            // tBoxMutation
            // 
            this.tBoxMutation.Location = new System.Drawing.Point(524, 90);
            this.tBoxMutation.Name = "tBoxMutation";
            this.tBoxMutation.Size = new System.Drawing.Size(100, 20);
            this.tBoxMutation.TabIndex = 17;
            this.tBoxMutation.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(464, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "µ";
            // 
            // bOneStep
            // 
            this.bOneStep.Location = new System.Drawing.Point(345, 146);
            this.bOneStep.Name = "bOneStep";
            this.bOneStep.Size = new System.Drawing.Size(75, 23);
            this.bOneStep.TabIndex = 19;
            this.bOneStep.Text = "Go";
            this.bOneStep.UseVisualStyleBackColor = true;
            this.bOneStep.Click += new System.EventHandler(this.bOneStep_Click);
            // 
            // bToEnd
            // 
            this.bToEnd.Location = new System.Drawing.Point(426, 146);
            this.bToEnd.Name = "bToEnd";
            this.bToEnd.Size = new System.Drawing.Size(75, 23);
            this.bToEnd.TabIndex = 20;
            this.bToEnd.Text = "Finish";
            this.bToEnd.UseVisualStyleBackColor = true;
            this.bToEnd.Click += new System.EventHandler(this.bToEnd_Click);
            // 
            // bInitialize
            // 
            this.bInitialize.Location = new System.Drawing.Point(719, 146);
            this.bInitialize.Name = "bInitialize";
            this.bInitialize.Size = new System.Drawing.Size(75, 23);
            this.bInitialize.TabIndex = 21;
            this.bInitialize.Text = "Initialize";
            this.bInitialize.UseVisualStyleBackColor = true;
            this.bInitialize.Click += new System.EventHandler(this.bInitialize_Click);
            // 
            // tBoxFormula
            // 
            this.tBoxFormula.Location = new System.Drawing.Point(326, 11);
            this.tBoxFormula.Name = "tBoxFormula";
            this.tBoxFormula.Size = new System.Drawing.Size(100, 20);
            this.tBoxFormula.TabIndex = 22;
            this.tBoxFormula.Text = "X+Y";
            // 
            // bChangeGA
            // 
            this.bChangeGA.Location = new System.Drawing.Point(508, 145);
            this.bChangeGA.Name = "bChangeGA";
            this.bChangeGA.Size = new System.Drawing.Size(75, 23);
            this.bChangeGA.TabIndex = 23;
            this.bChangeGA.Text = "ChangeGA";
            this.bChangeGA.UseVisualStyleBackColor = true;
            this.bChangeGA.Click += new System.EventHandler(this.bChangeGA_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 460);
            this.Controls.Add(this.bChangeGA);
            this.Controls.Add(this.tBoxFormula);
            this.Controls.Add(this.bInitialize);
            this.Controls.Add(this.bToEnd);
            this.Controls.Add(this.bOneStep);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tBoxMutation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tBoxAccuracy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.tBoxPercent);
            this.Controls.Add(this.tBoxExeEnd);
            this.Controls.Add(this.tBoxN);
            this.Controls.Add(this.tBoxX2Right);
            this.Controls.Add(this.tBoxX2Left);
            this.Controls.Add(this.tBoxX1Right);
            this.Controls.Add(this.tBoxX1Left);
            this.Name = "MainForm";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBoxX1Left;
        private System.Windows.Forms.TextBox tBoxX1Right;
        private System.Windows.Forms.TextBox tBoxX2Left;
        private System.Windows.Forms.TextBox tBoxX2Right;
        private System.Windows.Forms.TextBox tBoxN;
        private System.Windows.Forms.TextBox tBoxExeEnd;
        private System.Windows.Forms.TextBox tBoxPercent;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBoxAccuracy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBoxMutation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bOneStep;
        private System.Windows.Forms.Button bToEnd;
        private System.Windows.Forms.Button bInitialize;
        private System.Windows.Forms.TextBox tBoxFormula;
        private System.Windows.Forms.Button bChangeGA;
    }
}

