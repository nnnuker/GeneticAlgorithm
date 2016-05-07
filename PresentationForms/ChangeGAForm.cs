using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GeneticAlgorithm.Crossover;

namespace PresentationForms
{
    public partial class ChangeGAForm : Form
    {
        public ChangeGAForm()
        {
            InitializeComponent();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            
        }

        Dictionary<string, Type> dictionaryCrossover = new Dictionary<string, Type>
        {
            {"", typeof(OnePointCrossover)},
            {"", typeof(TwoPointsCrossover)}
        };


    }
}
