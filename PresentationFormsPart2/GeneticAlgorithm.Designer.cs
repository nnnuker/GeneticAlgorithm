namespace PresentationFormsPart2
{
    partial class GeneticAlgorithm
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxX2Right = new System.Windows.Forms.TextBox();
            this.tBoxX2Left = new System.Windows.Forms.TextBox();
            this.tBoxX1Right = new System.Windows.Forms.TextBox();
            this.tBoxX1Left = new System.Windows.Forms.TextBox();
            this.tBoxFormula = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBoxAccuracyTruncation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxAccuracySearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxTestStep = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBoxWorkStep = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBoxMutation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tBoxPercent = new System.Windows.Forms.TextBox();
            this.tBoxExeEnd = new System.Windows.Forms.TextBox();
            this.bInitialize = new System.Windows.Forms.Button();
            this.bToEnd = new System.Windows.Forms.Button();
            this.bOneStep = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.bShowAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bNextPoints = new System.Windows.Forms.Button();
            this.bPrevPoints = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(13, 39);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(300, 251);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "<= Y <=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "<= X <=";
            // 
            // tBoxX2Right
            // 
            this.tBoxX2Right.Location = new System.Drawing.Point(94, 65);
            this.tBoxX2Right.Name = "tBoxX2Right";
            this.tBoxX2Right.Size = new System.Drawing.Size(32, 20);
            this.tBoxX2Right.TabIndex = 15;
            this.tBoxX2Right.Text = "5";
            // 
            // tBoxX2Left
            // 
            this.tBoxX2Left.Location = new System.Drawing.Point(9, 65);
            this.tBoxX2Left.Name = "tBoxX2Left";
            this.tBoxX2Left.Size = new System.Drawing.Size(32, 20);
            this.tBoxX2Left.TabIndex = 14;
            this.tBoxX2Left.Text = "-5";
            // 
            // tBoxX1Right
            // 
            this.tBoxX1Right.Location = new System.Drawing.Point(94, 38);
            this.tBoxX1Right.Name = "tBoxX1Right";
            this.tBoxX1Right.Size = new System.Drawing.Size(32, 20);
            this.tBoxX1Right.TabIndex = 13;
            this.tBoxX1Right.Text = "10";
            // 
            // tBoxX1Left
            // 
            this.tBoxX1Left.Location = new System.Drawing.Point(9, 38);
            this.tBoxX1Left.Name = "tBoxX1Left";
            this.tBoxX1Left.Size = new System.Drawing.Size(32, 20);
            this.tBoxX1Left.TabIndex = 12;
            this.tBoxX1Left.Text = "-10";
            // 
            // tBoxFormula
            // 
            this.tBoxFormula.Location = new System.Drawing.Point(70, 15);
            this.tBoxFormula.Name = "tBoxFormula";
            this.tBoxFormula.Size = new System.Drawing.Size(204, 20);
            this.tBoxFormula.TabIndex = 23;
            this.tBoxFormula.Text = "2*(Y-X^2)^2+100*(1-X)^2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Truncation accuracy";
            // 
            // tBoxAccuracyTruncation
            // 
            this.tBoxAccuracyTruncation.Location = new System.Drawing.Point(121, 91);
            this.tBoxAccuracyTruncation.Name = "tBoxAccuracyTruncation";
            this.tBoxAccuracyTruncation.Size = new System.Drawing.Size(32, 20);
            this.tBoxAccuracyTruncation.TabIndex = 24;
            this.tBoxAccuracyTruncation.Text = "0.01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Search accuracy of the method";
            // 
            // tBoxAccuracySearch
            // 
            this.tBoxAccuracySearch.Location = new System.Drawing.Point(169, 117);
            this.tBoxAccuracySearch.Name = "tBoxAccuracySearch";
            this.tBoxAccuracySearch.Size = new System.Drawing.Size(32, 20);
            this.tBoxAccuracySearch.TabIndex = 26;
            this.tBoxAccuracySearch.Text = "0.01";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Test step";
            // 
            // tBoxTestStep
            // 
            this.tBoxTestStep.Location = new System.Drawing.Point(67, 143);
            this.tBoxTestStep.Name = "tBoxTestStep";
            this.tBoxTestStep.Size = new System.Drawing.Size(25, 20);
            this.tBoxTestStep.TabIndex = 28;
            this.tBoxTestStep.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Work step";
            // 
            // tBoxWorkStep
            // 
            this.tBoxWorkStep.Location = new System.Drawing.Point(67, 169);
            this.tBoxWorkStep.Name = "tBoxWorkStep";
            this.tBoxWorkStep.Size = new System.Drawing.Size(25, 20);
            this.tBoxWorkStep.TabIndex = 30;
            this.tBoxWorkStep.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "µ";
            // 
            // tBoxMutation
            // 
            this.tBoxMutation.Location = new System.Drawing.Point(32, 201);
            this.tBoxMutation.Name = "tBoxMutation";
            this.tBoxMutation.Size = new System.Drawing.Size(29, 20);
            this.tBoxMutation.TabIndex = 36;
            this.tBoxMutation.Text = "10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(132, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "End";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "n %";
            // 
            // tBoxPercent
            // 
            this.tBoxPercent.Location = new System.Drawing.Point(97, 201);
            this.tBoxPercent.Name = "tBoxPercent";
            this.tBoxPercent.Size = new System.Drawing.Size(29, 20);
            this.tBoxPercent.TabIndex = 33;
            this.tBoxPercent.Text = "80";
            // 
            // tBoxExeEnd
            // 
            this.tBoxExeEnd.Location = new System.Drawing.Point(164, 201);
            this.tBoxExeEnd.Name = "tBoxExeEnd";
            this.tBoxExeEnd.Size = new System.Drawing.Size(29, 20);
            this.tBoxExeEnd.TabIndex = 32;
            this.tBoxExeEnd.Text = "10";
            // 
            // bInitialize
            // 
            this.bInitialize.Location = new System.Drawing.Point(199, 199);
            this.bInitialize.Name = "bInitialize";
            this.bInitialize.Size = new System.Drawing.Size(75, 23);
            this.bInitialize.TabIndex = 40;
            this.bInitialize.Text = "Initialize";
            this.bInitialize.UseVisualStyleBackColor = true;
            this.bInitialize.Click += new System.EventHandler(this.bInitialize_Click);
            // 
            // bToEnd
            // 
            this.bToEnd.Location = new System.Drawing.Point(413, 267);
            this.bToEnd.Name = "bToEnd";
            this.bToEnd.Size = new System.Drawing.Size(75, 23);
            this.bToEnd.TabIndex = 39;
            this.bToEnd.Text = "Finish";
            this.bToEnd.UseVisualStyleBackColor = true;
            this.bToEnd.Click += new System.EventHandler(this.bToEnd_Click);
            // 
            // bOneStep
            // 
            this.bOneStep.Location = new System.Drawing.Point(332, 267);
            this.bOneStep.Name = "bOneStep";
            this.bOneStep.Size = new System.Drawing.Size(75, 23);
            this.bOneStep.TabIndex = 38;
            this.bOneStep.Text = "Go";
            this.bOneStep.UseVisualStyleBackColor = true;
            this.bOneStep.Click += new System.EventHandler(this.bOneStep_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 296);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(604, 225);
            this.dataGridView.TabIndex = 41;
            // 
            // bShowAll
            // 
            this.bShowAll.Location = new System.Drawing.Point(542, 267);
            this.bShowAll.Name = "bShowAll";
            this.bShowAll.Size = new System.Drawing.Size(75, 23);
            this.bShowAll.TabIndex = 42;
            this.bShowAll.Text = "Show";
            this.bShowAll.UseVisualStyleBackColor = true;
            this.bShowAll.Click += new System.EventHandler(this.bShowAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tBoxX1Left);
            this.groupBox1.Controls.Add(this.tBoxX1Right);
            this.groupBox1.Controls.Add(this.tBoxX2Left);
            this.groupBox1.Controls.Add(this.bInitialize);
            this.groupBox1.Controls.Add(this.tBoxX2Right);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tBoxFormula);
            this.groupBox1.Controls.Add(this.tBoxMutation);
            this.groupBox1.Controls.Add(this.tBoxAccuracyTruncation);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tBoxAccuracySearch);
            this.groupBox1.Controls.Add(this.tBoxPercent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tBoxExeEnd);
            this.groupBox1.Controls.Add(this.tBoxTestStep);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tBoxWorkStep);
            this.groupBox1.Location = new System.Drawing.Point(332, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 247);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Expression";
            // 
            // bNextPoints
            // 
            this.bNextPoints.Location = new System.Drawing.Point(238, 10);
            this.bNextPoints.Name = "bNextPoints";
            this.bNextPoints.Size = new System.Drawing.Size(75, 23);
            this.bNextPoints.TabIndex = 44;
            this.bNextPoints.Text = "=>";
            this.bNextPoints.UseVisualStyleBackColor = true;
            this.bNextPoints.Click += new System.EventHandler(this.bNextPoints_Click);
            // 
            // bPrevPoints
            // 
            this.bPrevPoints.Location = new System.Drawing.Point(12, 10);
            this.bPrevPoints.Name = "bPrevPoints";
            this.bPrevPoints.Size = new System.Drawing.Size(75, 23);
            this.bPrevPoints.TabIndex = 45;
            this.bPrevPoints.Text = "<=";
            this.bPrevPoints.UseVisualStyleBackColor = true;
            this.bPrevPoints.Click += new System.EventHandler(this.bPrevPoints_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(136, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 42;
            // 
            // GeneticAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 526);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bPrevPoints);
            this.Controls.Add(this.bNextPoints);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bShowAll);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.bToEnd);
            this.Controls.Add(this.bOneStep);
            this.Controls.Add(this.chart1);
            this.Name = "GeneticAlgorithm";
            this.Text = "GeneticAlgorithm";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxX2Right;
        private System.Windows.Forms.TextBox tBoxX2Left;
        private System.Windows.Forms.TextBox tBoxX1Right;
        private System.Windows.Forms.TextBox tBoxX1Left;
        private System.Windows.Forms.TextBox tBoxFormula;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBoxAccuracyTruncation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBoxAccuracySearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBoxTestStep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBoxWorkStep;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBoxMutation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBoxPercent;
        private System.Windows.Forms.TextBox tBoxExeEnd;
        private System.Windows.Forms.Button bInitialize;
        private System.Windows.Forms.Button bToEnd;
        private System.Windows.Forms.Button bOneStep;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button bShowAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bNextPoints;
        private System.Windows.Forms.Button bPrevPoints;
        private System.Windows.Forms.Label label11;
    }
}

