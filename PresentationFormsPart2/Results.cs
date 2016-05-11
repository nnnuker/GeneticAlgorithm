using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PresentationFormsPart2
{
    public partial class Results : Form
    {
        private ResultsData dataAdapter;
        private DesignPointsGraph graphAdapter;
        private List<ParseDesignPointViewModel> listParse;

        public Results()
        {
            InitializeComponent();
            dataAdapter = new ResultsData(dataGridView1);
        }

        private void Results_Load(object sender, EventArgs e)
        {
            
            var writePath = "result.json";

            var json = File.ReadAllText(writePath);
            listParse = new List<ParseDesignPointViewModel>();

            while (json != "")
            {
                var part = json.Substring(0, json.IndexOf("}") + 1);
                listParse.Add(JsonConvert.DeserializeObject<ParseDesignPointViewModel>(part));
                json = json.Remove(0, json.IndexOf("}") + 1);
            }

            foreach (var parseDesignPointViewModel in listParse)
            {
                dataAdapter.Add(parseDesignPointViewModel);
            }

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgw = (DataGridView)sender;
            var currentRow = dgw.CurrentRow.Index;

            var chromosomes = new IChromosome[]
            {
                new ChromosomeNumeric(5, 12, listParse[currentRow].N, "N"),
                new ChromosomeNumeric(3,5, listParse[currentRow].n, "n"),
                new ChromosomeNumeric(1,1, listParse[currentRow].Population, "population"), // - Net
                new ChromosomeNumeric(1,4, listParse[currentRow].SelectStartPoints, "selectStartPoints"),
                new ChromosomeNumeric(1,1, listParse[currentRow].SearchMethod, "searchMethod"), // - Huk
                new ChromosomeNumeric(1,2, listParse[currentRow].Search, "search"),
                new ChromosomeNumeric(1,3, listParse[currentRow].SelectOtherPoints, "selectOtherPoints")
            };

            FuncCalculatorTruncation funcCalculator = new FuncCalculatorTruncation(tBoxFormula.Text, DoubleParser(tBoxX1Left), DoubleParser(tBoxX1Right),
                DoubleParser(tBoxX2Left), DoubleParser(tBoxX2Right), DoubleParser(tBoxTestStep), DoubleParser(tBoxWorkStep),
                DoubleParser(tBoxAccuracySearch), DoubleParser(tBoxAccuracyTruncation));

            //funcCalculator.CalculateFunc(chromosomes);

            List<IDesignPoint> ll = new List<IDesignPoint>();

            foreach (var designPoint in funcCalculator.AllPoints)
            {
                ll.Add(designPoint);
            }

            var drawer = new DesignPointViewModel(new DesignPoint(0, 0, funcCalculator, chromosomes));

            graphAdapter = new DesignPointsGraph(chart1, IntParser(tBoxX1Left), IntParser(tBoxX1Right),
                IntParser(tBoxX2Left), IntParser(tBoxX2Right));

            graphAdapter.DrawFirstBestVersion(drawer);

            label11.Text = "1";

        }

        private double DoubleParser(TextBox textBox)
        {
            double result;
            var flag = double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out result);

            if (!flag)
            {
                throw new FormatException(textBox.Name);
            }

            return result;
        }

        private int IntParser(TextBox textBox)
        {
            int result;
            var flag = int.TryParse(textBox.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);

            if (!flag)
            {
                throw new FormatException();
            }

            return result;
        }
        private void bShowAll_Click(object sender, EventArgs e)
        {
            Results results = new Results();
            results.Show();
        }

        private void bPrevPoints_Click(object sender, EventArgs e)
        {
            DesignPointsGraph.numberId--;
            graphAdapter.DrawPrevNextBestVersion();
            label11.Text = DesignPointsGraph.numberId.ToString();
        }

        private void bNextPoints_Click(object sender, EventArgs e)
        {
            DesignPointsGraph.numberId++;
            graphAdapter.DrawPrevNextBestVersion();
            label11.Text = DesignPointsGraph.numberId.ToString();
        }
    }
}
