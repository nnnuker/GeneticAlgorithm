using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GeneticAlgorithm;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.Crossover;
using GeneticAlgorithm.Descendants;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FactoryPoint;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.Mutation;
using GeneticAlgorithm.PairFormation;
using GeneticAlgorithm.Population;
using GeneticAlgorithm.SelectPoints;
using Newtonsoft.Json;
using Point = GeneticAlgorithm.DesignPoints.Point;

namespace PresentationFormsPart2
{
    public partial class GeneticAlgorithm : Form
    {
        #region Fields

        private DesignPointsData dataAdapter;
        private DesignPointsGraph graphAdapter;
        private GAlgorithm algorithm;
        private JsonSerializer serializer;

        #endregion

        #region Constructor

        public GeneticAlgorithm()
        {
            InitializeComponent();
        }

        #endregion

        #region Steps

        private void bOneStep_Click(object sender, EventArgs e)
        {
            label11.Text = "1";
            algorithm.MoveNext();
            AppData();
        }

        private void bToEnd_Click(object sender, EventArgs e)
        {
            label11.Text = "1";
            for (int i = algorithm.PopulationNumber; i < int.Parse(tBoxExeEnd.Text); i++)
            {
                //if (algorithm.CurrentDesignPoints.Count(y => y.IsAlive) == 0)
                //{
                //    GetBest();
                //    return;
                //}
                algorithm.MoveNext();
                AppData();
            }
            GetBest();
        }

        #endregion

        #region Append data

        private void AppData()
        {
            var res1 = algorithm.ListOfSelectedPoints.Select(x => new DesignPointViewModel(x));
            dataAdapter.AddPopulation(res1, Color.Blue);
            var res2 = algorithm.ListOfFirst.Select(x => new DesignPointViewModel(x));
            dataAdapter.AddPopulation(res2, Color.BlueViolet);
            var res3 = algorithm.ListOfSecond.Select(x => new DesignPointViewModel(x));
            dataAdapter.AddPopulation(res3, Color.Brown);
            var res = algorithm.CurrentDesignPoints.Select(x => new DesignPointViewModel(x));
            //graphAdapter.DrawFirstBestVersion(best);
            var rr = dataAdapter.AddPopulation(res, Color.LightGreen);
            if (rr == null)
            {
                return;
            }
            else
            {
                graphAdapter.DrawFirstBestVersion(rr);
            }
        }

        private void GetBest()
        {
            var best = algorithm.ListOfAllDesignPoints
                .Where(y => y.IsAlive)
                .OrderBy(x => x.FunctionValue)
                .Select(x => new DesignPointViewModel(x))
                .First();
            dataAdapter.AddBest(best);
            graphAdapter.DrawFirstBestVersion(best);

            var writePath = "result.json";

            var ss = new List<Point>();
            foreach (var item in best.AllPoints)
            {
                ss.Add((Point)item);
            }

            using (StreamWriter file = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                var bestParse = new ParseDesignPointViewModel()
                {
                    N = best.N,
                    n = best.n,
                    Population = best.Population,
                    SelectStartPoints = best.SelectStartPoints,
                    SearchMethod = best.SearchMethod,
                    Search = best.Search,
                    SelectOtherPoints = best.SelectOtherPoints,
                };
                serializer.Serialize(file, bestParse);
            }

        }

        #endregion

        private void Initialize(double accuracyTruncation, double accuracySearch, int workStep, int testStep,
            int m, int percent, int end, double minX, double maxX, double minY, double maxY, string formula)
        {
            IFuncCalculator funcCalculator = new FuncCalculatorTruncation(formula, minX, maxX, minY, maxY, testStep,
                workStep, accuracySearch, accuracyTruncation);

            IFactoryPoints factoryPoint = new CreateDesignPoint(funcCalculator);

            IChromosome chromoN = new ChromosomeNumeric(5, 12, 0, "N");
            IChromosome chromo_n = new ChromosomeNumeric(3, 5, 0, "n");
            IChromosome chromoPopulation = new ChromosomeNumeric(1, 1, 0, "population"); // - Net
            IChromosome chromoSelectStartPoints = new ChromosomeNumeric(1, 4, 0, "selectStartPoints");
            IChromosome chromoSearchMethod = new ChromosomeNumeric(1, 1, 0, "searchMethod"); // - Huk
            IChromosome chromoSearch = new ChromosomeNumeric(1, 2, 0, "search");
            IChromosome chromoSelectOtherPoints = new ChromosomeNumeric(1, 3, 0, "selectOtherPoints");

            int N = 10;
            IPopulation population = new RandomPopulation(factoryPoint, N, 1, chromoN, chromo_n, chromoPopulation, 
                chromoSelectStartPoints, chromoSearchMethod, chromoSearch, chromoSelectOtherPoints);

            ISelectPoints selectPoints = new RouletteSelectPoints();

            ICrossover crossover = new OnePointCrossover();
            IMutation mutation = new MutationNumeric(m);
            IPairFormation pairFormation = new RandomPairFormation();

            IDescendants descendants = new CrossoverMutation(crossover, mutation, pairFormation,
                CrossoverMutation.ParentDescendants);

            algorithm = new GAlgorithm(end, percent, population, selectPoints, descendants);
        }

        private void bInitialize_Click(object sender, EventArgs e)
        {
            label11.Text = "1";
            var addRange = 1;

            try
            {
                var leftX1 = DoubleParser(tBoxX1Left);
                var rightX1 = DoubleParser(tBoxX1Right);
                var leftX2 = DoubleParser(tBoxX2Left);
                var rightX2 = DoubleParser(tBoxX2Right);
                var accuracyTruncation = DoubleParser(tBoxAccuracyTruncation);
                var accuracySearch = DoubleParser(tBoxAccuracySearch);
                var workStep = IntParser(tBoxWorkStep);
                var testStep = IntParser(tBoxTestStep);
                var m = IntParser(tBoxMutation);
                var percent = IntParser(tBoxPercent);
                var end = IntParser(tBoxExeEnd);

                
                graphAdapter = new DesignPointsGraph(chart1, (int)leftX1 - addRange, (int)rightX1 + addRange,
                    (int)leftX2 - addRange, (int)rightX2 + addRange);
                dataAdapter = new DesignPointsData(dataGridView);
                Initialize(accuracyTruncation, accuracySearch, workStep, testStep, m, percent, end, 
                    leftX1, rightX1, leftX2, rightX2, tBoxFormula.Text);
                serializer = new JsonSerializer();
                AppData();
            }
            catch (FormatException exception)
            {
                MessageBox.Show($"Please write correct data in {exception.Message}.");
            }
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
            results.ShowDialog();
        }

        private void bPrevPoints_Click(object sender, EventArgs e)
        {
            DesignPointsGraph.numberId --;
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
