using System;
using System.Linq;
using System.Windows.Forms;
using GeneticAlgorithm;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.Crossover;
using GeneticAlgorithm.Descendants;
using GeneticAlgorithm.FactoryPoint;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.Mutation;
using GeneticAlgorithm.PairFormation;
using GeneticAlgorithm.Population;
using GeneticAlgorithm.SelectPoints;

namespace PresentationForms
{
    public partial class MainForm : Form
    {
        #region Fields

        private DesignPointsData dataAdapter;
        private DesignPointsGraph graphAdapter;
        private GAlgorithm algorithm;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        private void bToEnd_Click(object sender, EventArgs e)
        {
            for (int i = algorithm.PopulationNumber; i < int.Parse(tBoxExeEnd.Text); i++)
            {
                algorithm.MoveNext();
                AppData();
            }
        }

        private void bOneStep_Click(object sender, EventArgs e)
        {
            algorithm.MoveNext();
            AppData();
        }

        private void AppData()
        {
            var res = algorithm.CurrentDesignPoints.Select(x => new DesignPointViewModel(x));
            dataAdapter.AddPopulation(res);
            graphAdapter.AddRange(res);
        }

        private void Initialize(int accuracy, int N, int m, int percent, int end, int minX, int maxX, 
            int minY, int maxY, string formula)
        {
            IFuncCalculator funcCalculator = new FuncCalculatorBasic(formula);

            IFactoryPoints factoryPoint = new CreateDesignPoint(funcCalculator);

            IChromosome chromoX = new Chromosome(accuracy, minX, maxX, 0, "X");
            IChromosome chromoY = new Chromosome(accuracy, minY, maxY, 0, "Y");

            IPopulation population = new RandomPopulation(factoryPoint, N, 1, chromoX, chromoY);

            ISelectPoints selectPoints = new ClassicRouletteSelectPoints();

            ICrossover crossover = new OnePointCrossover();
            IMutation mutation = new MutationBinary(m);
            IPairFormation pairFormation = new RandomPairFormation();

            IDescendants descendants = new CrossoverMutation(crossover, mutation, pairFormation,
                CrossoverMutation.ParentDescendants);

            algorithm = new GAlgorithm(end, percent, population, selectPoints, descendants);
        }

        private void bInitialize_Click(object sender, EventArgs e)
        {
            var addRange = 1;
            var leftX1 = (int)double.Parse(tBoxX1Left.Text);
            var rightX1 = (int)double.Parse(tBoxX1Right.Text);
            var leftX2 = (int)double.Parse(tBoxX2Left.Text);
            var rightX2 = (int)double.Parse(tBoxX2Right.Text);

            dataAdapter = new DesignPointsData(dataGridView);
            graphAdapter = new DesignPointsGraph(chart, leftX1 - addRange, rightX1 + addRange,
                leftX2 - addRange, rightX2 + addRange);

            var accuracy = int.Parse(tBoxAccuracy.Text);
            var N = int.Parse(tBoxN.Text);
            var m = int.Parse(tBoxMutation.Text);
            var percent = int.Parse(tBoxPercent.Text);
            var end = int.Parse(tBoxExeEnd.Text);

            Initialize(accuracy, N, m, percent, end, leftX1, rightX1, leftX2, rightX2, tBoxFormula.Text);
            AppData();
        }
    }
}
