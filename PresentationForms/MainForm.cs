using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private DesignPointsData dataAdapter;
        private DesignPointsGraph graphAdapter;
        private BindingList<DesignPointViewModel> gridDataSource = new BindingList<DesignPointViewModel>();
        private GAlgorithm algorithm;

        public MainForm()
        {
            InitializeComponent();

            dataAdapter = new DesignPointsData(dataGridView);
            graphAdapter = new DesignPointsGraph(chart);

            Initialize();
            AppData();
        }

        private void bToEnd_Click(object sender, EventArgs e)
        {

        }

        private void bOneStep_Click(object sender, EventArgs e)
        {
            if (algorithm == null)
            {
                Initialize();
            }

            algorithm.MoveNext();
            AppData();
        }

        private void AppData()
        {
            var res = algorithm.listOfCurrentDesignPoints.Select(x => new DesignPointViewModel(x));
            dataAdapter.AddPopulation(res);
            graphAdapter.AddRange(res);
        }

        private void Initialize()
        {

            IFuncCalculator funcCalculator = new FuncCalculatorBasic("X+Y");

            IFactoryPoints factoryPoint = new CreateDesignPoint(funcCalculator);

            IChromosome chromoX = new Chromosome(1, -4, 4, 0, "X");
            IChromosome chromoY = new Chromosome(1, -10, 10, 0, "Y");

            IPopulation population = new RandomPopulation(factoryPoint, 20, 1, chromoX, chromoY);

            ISelectPoints selectPoints = new ClassicRouletteSelectPoints();

            ICrossover crossover = new OnePointCrossover();
            IMutation mutation = new MutationBinary(10);
            IPairFormation pairFormation = new RandomPairFormation();

            IDescendants descendants = new CrossoverMutation(crossover, mutation, pairFormation,
                CrossoverMutation.ParentDescendants);

            algorithm = new GAlgorithm(10, 80, population, selectPoints, descendants);
        }
    }
}
