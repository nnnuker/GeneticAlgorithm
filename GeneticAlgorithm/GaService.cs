using System;
using System.Collections.Generic;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.Crossover;
using GeneticAlgorithm.Descendants;
using GeneticAlgorithm.FactoryPoint;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.Mutation;
using GeneticAlgorithm.PairFormation;
using GeneticAlgorithm.Population;
using GeneticAlgorithm.SelectPoints;

namespace GeneticAlgorithm
{
    public static class GaService
    {
        #region Fields

        private static string crossover;
        private static string population;
        private static string selectPoints;
        private static string pairFormation;
        private static string descendants;

        #endregion

        #region Properties

        public static Dictionary<string, Type> DictionaryPopulation { get; set; }
        public static Dictionary<string, Type> DictionaryCrossover { get; set; }
        public static Dictionary<string, Type> DictionarySelectPoints { get; set; }
        public static Dictionary<string, Type> DictionaryPairFormation { get; set; }
        public static Dictionary<string, Type> DictionaryDescendants { get; set; }

        #endregion

        #region Constructor

        static GaService()
        {
            crossover = "Single point";
            population = "Random";
            selectPoints = "Roulette";
            pairFormation = "Random";
            descendants = "Crossover mutation";

            DictionaryPopulation = new Dictionary<string, Type>
            {
                {"Random", typeof(RandomPopulation)},
                {"Net", typeof(NetPopulation)}
            };

            DictionaryCrossover = new Dictionary<string, Type>
            {
                {"Single point", typeof(OnePointCrossover)},
                {"Two point", typeof(TwoPointsCrossover)}
            };

            DictionarySelectPoints = new Dictionary<string, Type>
            {
                {"Roulette", typeof(RouletteSelectPoints)},
                {"Classic roulette", typeof(ClassicRouletteSelectPoints)},
                {"Rang", typeof(RangSelectPoints)},
                {"Tour", typeof(TourSelectPoints)},
                {"Best", typeof(BestSelectPoints)}
            };

            DictionaryPairFormation = new Dictionary<string, Type>
            {
                {"Random", typeof(RandomPairFormation)},
                {"Several best", typeof(SeveralBestPairFormation)},
                {"Best worse", typeof(BestWorsePairFormation)}
            };

            DictionaryDescendants = new Dictionary<string, Type>
            {
                {"Crossover mutation", typeof(CrossoverMutation)},
                {"Mutation crossover", typeof(MutationCrossover)},
                {"Crossover mutation descendants", typeof(CrossoverMutationDesc)},
                {"Mutation crossover descendants", typeof(MutationCrossoverDesc)}
            };
        }

        #endregion

        #region Public methods

        public static void SetArguments(string crossover, string population, string selectPoints,
            string pairFormation, string descendants)
        {
            GaService.crossover = crossover;
            GaService.population = population;
            GaService.selectPoints = selectPoints;
            GaService.pairFormation = pairFormation;
            GaService.descendants = descendants;
        }

        public static GAlgorithm GetGa(int accuracy, int N, int m, int percent, int end, double minX, double maxX,
            double minY, double maxY, string formula)
        {
            var initPopulation = InitializePopulation(accuracy, N, minX, maxX, minY, maxY, formula);
            var initSelectPoints = InitializeSelectPoints();

            var initDescendants = InitializeDescendants(m);

            return new GAlgorithm(end, percent, initPopulation, initSelectPoints, initDescendants);
        }

        #endregion

        #region Private methods

        private static IPopulation InitializePopulation(int accuracy, int N, double minX, double maxX,
            double minY, double maxY, string formula)
        {
            IFuncCalculator funcCalculator = new FuncCalculatorBasic(formula);

            IFactoryPoints factoryPoint = new CreateDesignPoint(funcCalculator);

            IChromosome chromoX = new Chromosome.Chromosome(accuracy, minX, maxX, 0, "X");
            IChromosome chromoY = new Chromosome.Chromosome(accuracy, minY, maxY, 0, "Y");

            return (IPopulation)Activator.CreateInstance(DictionaryPopulation[population], factoryPoint, N, 1, chromoX, chromoY);
        }

        private static ICrossover InitializeCrossover()
        {
            return (ICrossover)Activator.CreateInstance(DictionaryCrossover[crossover]);
        }

        private static ISelectPoints InitializeSelectPoints()
        {
            return (ISelectPoints)Activator.CreateInstance(DictionarySelectPoints[selectPoints]);
        }

        private static IPairFormation InitializePairFormation()
        {
            return (IPairFormation)Activator.CreateInstance(DictionaryPairFormation[pairFormation]);
        }

        private static IDescendants InitializeDescendants(int m)
        {
            var initCrossover = InitializeCrossover();
            var initPairFormation = InitializePairFormation();
            IMutation mutation = new MutationBinary(m);

            return
                (IDescendants)
                    Activator.CreateInstance(DictionaryDescendants[descendants], initCrossover,
                    mutation, initPairFormation);
        }
        #endregion
    }
}