using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using GeneticAlgorithm;
using ORM;

namespace PresentationForms
{
    public partial class ChangeGAForm : Form
    {
        public ChangeGAForm()
        {
            InitializeComponent();

            cbPopulation.DataSource = ResultService.GetPopulations();
            cbPopulation.DisplayMember = "PopulationName";

            cbCrossover.DataSource = ResultService.GetCrossovers();
            cbCrossover.DisplayMember = "CrossoverName";

            cbDescendants.DataSource = ResultService.GetDescendants();
            cbDescendants.DisplayMember = "DescendantsName";

            cbPairFormation.DataSource = ResultService.GetPairFormations();
            cbPairFormation.DisplayMember = "PairFormationName";

            cbSelectPoints.DataSource = ResultService.GetSelectPoints();
            cbSelectPoints.DisplayMember = "SelectPointsName";

            dGVResults.DataSource = ResultService.GetResults().Select(x => new ResultsViewModel(x)).ToList();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            var population = ((Population)cbPopulation.SelectedItem).PopulationId;
            var crossover = ((Crossover)cbCrossover.SelectedItem).CrossoverId;
            var selectPoints = ((SelectPoint)cbSelectPoints.SelectedItem).SelectPointsId;
            var descendants = ((Descendant)cbDescendants.SelectedItem).DescendantsId;
            var pairFormation = ((PairFormation)cbPairFormation.SelectedItem).PairFormationId;

            ResultService.AddResult(population, crossover, descendants, selectPoints, pairFormation);
            GaService.SetArguments(cbCrossover.Text, cbPopulation.Text, cbSelectPoints.Text,
                cbPairFormation.Text, cbDescendants.Text);

            this.Close();
        }
    }
}
