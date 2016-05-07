using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Crossover;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Mutation;
using GeneticAlgorithm.PairFormation;

namespace GeneticAlgorithm.Descendants
{
    public class CrossoverMutation : IDescendants
    {
        #region Fields

        private static ICrossover crossover;
        private static IMutation mutation;
        private static IPairFormation pairFormation;
        private readonly NewPopulation newPopulation;
        private static List<IDesignPoint> listOfAllDesignPoints;
        private static IEnumerable<IDesignPoint> listOfSecond;
        private static IEnumerable<IDesignPoint> listOfFirst;

        #endregion

        #region Delegate

        public delegate IEnumerable<IDesignPoint> NewPopulation(IEnumerable<IDesignPoint> designPoints);

        #endregion

        #region Property

        public IEnumerable<IDesignPoint> GetAllDesignPoints => listOfAllDesignPoints;
        public IEnumerable<IDesignPoint> GetAfterFirst => listOfFirst;
        public IEnumerable<IDesignPoint> GetAfterSecond => listOfSecond;

        #endregion

        #region Constructors

        public CrossoverMutation() : this(null, null, null, null)
        {
        }

        public CrossoverMutation(ICrossover crossover, IMutation mutation, IPairFormation pairFormation,
            NewPopulation newPopulation)
        {
            if (crossover == null) throw new ArgumentNullException(nameof(crossover));
            if (mutation == null) throw new ArgumentNullException(nameof(mutation));
            if (pairFormation == null) throw new ArgumentNullException(nameof(pairFormation));
            if (newPopulation == null) throw new ArgumentNullException(nameof(newPopulation));

            CrossoverMutation.crossover = crossover;
            CrossoverMutation.mutation = mutation;
            CrossoverMutation.pairFormation = pairFormation;
            this.newPopulation = newPopulation;
            listOfAllDesignPoints = new List<IDesignPoint>();
            listOfFirst= new List<IDesignPoint>();
            listOfSecond = new List<IDesignPoint>();
        }

        #endregion

        #region Public method

        public IEnumerable<IDesignPoint> GetDescendants(IEnumerable<IDesignPoint> designPoints)
        {
            listOfAllDesignPoints = new List<IDesignPoint>();
            return newPopulation(designPoints);
        }

        public static IEnumerable<IDesignPoint> ParentMutationCrossover(IEnumerable<IDesignPoint> designPoints)
        {
            var list = new List<IDesignPoint>();

            var pairs = pairFormation.FormatPairs(designPoints);

            crossover.PopulationNumber++;
            crossover.PopulationId = 1;

            var crossovered = crossover.Crossover(pairs);

            listOfFirst = crossovered;

            list.AddRange(crossovered.Where(x=>x.IsAlive));

            mutation.PopulationNumber = crossover.PopulationNumber;
            mutation.PopulationId = crossover.PopulationId;

            mutation.Mutate(crossovered);

            listOfSecond = mutation.MutateDesignPoints;

            list.AddRange(mutation.MutateDesignPoints);

            listOfAllDesignPoints = list;

            return list;
        }

        public static IEnumerable<IDesignPoint> ParentDescendants(IEnumerable<IDesignPoint> designPoints)
        {
            var pairs = pairFormation.FormatPairs(designPoints);

            crossover.PopulationNumber++;
            crossover.PopulationId = 1;

            var crossovered = crossover.Crossover(pairs);
            listOfFirst = crossovered;
            mutation.PopulationNumber = crossover.PopulationNumber;
            mutation.PopulationId = crossover.PopulationId;

            mutation.Mutate(crossovered.Where(x => x.IsAlive));
            listOfSecond = mutation.AllDesignPoints;
            listOfAllDesignPoints = mutation.AllDesignPoints;

            return listOfAllDesignPoints;
        }

        #endregion

    }
}
