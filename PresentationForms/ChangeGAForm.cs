using System;
using System.Linq;
using System.Windows.Forms;
using GeneticAlgorithm;

namespace PresentationForms
{
    public partial class ChangeGAForm : Form
    {
        public ChangeGAForm()
        {
            InitializeComponent();

            cbPopulation.DataSource = GaService.DictionaryPopulation.Keys.ToList();
            cbCrossover.DataSource = GaService.DictionaryCrossover.Keys.ToList();
            cbDescendants.DataSource = GaService.DictionaryDescendants.Keys.ToList();
            cbPairFormation.DataSource = GaService.DictionaryPairFormation.Keys.ToList();
            cbSelectPoints.DataSource = GaService.DictionarySelectPoints.Keys.ToList();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            GaService.SetArguments(cbCrossover.Text, cbPopulation.Text, cbSelectPoints.Text,
                cbPairFormation.Text, cbDescendants.Text);

            this.Close();
        }
    }
}
