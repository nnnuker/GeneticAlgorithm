namespace PresentationForms
{
    partial class ChangeGAForm
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
            this.cbPopulation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPairFormation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCrossover = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDescendants = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSelectPoints = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbNewPopulation = new System.Windows.Forms.ComboBox();
            this.bOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbPopulation
            // 
            this.cbPopulation.FormattingEnabled = true;
            this.cbPopulation.Items.AddRange(new object[] {
            "Random",
            "Net"});
            this.cbPopulation.Location = new System.Drawing.Point(12, 29);
            this.cbPopulation.Name = "cbPopulation";
            this.cbPopulation.Size = new System.Drawing.Size(121, 21);
            this.cbPopulation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Population";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pair formation";
            // 
            // cbPairFormation
            // 
            this.cbPairFormation.FormattingEnabled = true;
            this.cbPairFormation.Items.AddRange(new object[] {
            "Random",
            "Several best",
            "Best worse"});
            this.cbPairFormation.Location = new System.Drawing.Point(12, 73);
            this.cbPairFormation.Name = "cbPairFormation";
            this.cbPairFormation.Size = new System.Drawing.Size(121, 21);
            this.cbPairFormation.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Crossover";
            // 
            // cbCrossover
            // 
            this.cbCrossover.FormattingEnabled = true;
            this.cbCrossover.Items.AddRange(new object[] {
            "Single point",
            "Two point"});
            this.cbCrossover.Location = new System.Drawing.Point(149, 73);
            this.cbCrossover.Name = "cbCrossover";
            this.cbCrossover.Size = new System.Drawing.Size(121, 21);
            this.cbCrossover.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Descendants";
            // 
            // cbDescendants
            // 
            this.cbDescendants.FormattingEnabled = true;
            this.cbDescendants.Items.AddRange(new object[] {
            "Crossover -> mutation",
            "Mutation -> crossover"});
            this.cbDescendants.Location = new System.Drawing.Point(149, 113);
            this.cbDescendants.Name = "cbDescendants";
            this.cbDescendants.Size = new System.Drawing.Size(121, 21);
            this.cbDescendants.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Select points";
            // 
            // cbSelectPoints
            // 
            this.cbSelectPoints.FormattingEnabled = true;
            this.cbSelectPoints.Items.AddRange(new object[] {
            "Classic roulette",
            "Roulette",
            "Rang",
            "Tour",
            "Best"});
            this.cbSelectPoints.Location = new System.Drawing.Point(149, 29);
            this.cbSelectPoints.Name = "cbSelectPoints";
            this.cbSelectPoints.Size = new System.Drawing.Size(121, 21);
            this.cbSelectPoints.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "New population";
            // 
            // cbNewPopulation
            // 
            this.cbNewPopulation.FormattingEnabled = true;
            this.cbNewPopulation.Items.AddRange(new object[] {
            "Descendants",
            "Crossover with mutation"});
            this.cbNewPopulation.Location = new System.Drawing.Point(12, 113);
            this.cbNewPopulation.Name = "cbNewPopulation";
            this.cbNewPopulation.Size = new System.Drawing.Size(121, 21);
            this.cbNewPopulation.TabIndex = 11;
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(12, 141);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 12;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // ChangeGAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 360);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.cbNewPopulation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbSelectPoints);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbDescendants);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCrossover);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPairFormation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPopulation);
            this.Name = "ChangeGAForm";
            this.Text = "ChangeGAForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPopulation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPairFormation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCrossover;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDescendants;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSelectPoints;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbNewPopulation;
        private System.Windows.Forms.Button bOk;
    }
}