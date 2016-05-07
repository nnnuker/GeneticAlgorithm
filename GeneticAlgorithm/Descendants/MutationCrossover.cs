using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Crossover;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Mutation;
using GeneticAlgorithm.PairFormation;

namespace GeneticAlgorithm.Descendants
{
    public class MutationCrossover : IDescendants
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

        public MutationCrossover() : this(null, null, null, null)
        {
        }

        public MutationCrossover(ICrossover crossover, IMutation mutation, IPairFormation pairFormation,
            NewPopulation newPopulation)
        {
            if (crossover == null) throw new ArgumentNullException(nameof(crossover));
            if (mutation == null) throw new ArgumentNullException(nameof(mutation));
            if (pairFormation == null) throw new ArgumentNullException(nameof(pairFormation));
            if (newPopulation == null) throw new ArgumentNullException(nameof(newPopulation));

            MutationCrossover.crossover = crossover;
            MutationCrossover.mutation = mutation;
            MutationCrossover.pairFormation = pairFormation;
            this.newPopulation = newPopulation;
            listOfAllDesignPoints = new List<IDesignPoint>();
            listOfFirst = new List<IDesignPoint>();
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

            mutation.PopulationNumber++;
            mutation.PopulationId = 1;

            mutation.Mutate(designPoints);

            listOfFirst = mutation.AllDesignPoints;

            list.AddRange(mutation.AllDesignPoints.Where(x => x.IsAlive));

            var pairs = pairFormation.FormatPairs(list);

            crossover.PopulationNumber = mutation.PopulationNumber;
            crossover.PopulationId = mutation.PopulationId;

            var crossovered = crossover.Crossover(pairs);

            listOfSecond = crossovered;
            list.AddRange(crossovered);

            listOfAllDesignPoints.AddRange(list);

            return list;
        }

        public static IEnumerable<IDesignPoint> ParentDescendants(IEnumerable<IDesignPoint> designPoints)
        {
            mutation.PopulationNumber++;
            mutation.PopulationId = 1;

            mutation.Mutate(designPoints);
            listOfFirst = mutation.AllDesignPoints;
            listOfAllDesignPoints.AddRange(mutation.AllDesignPoints.Where(x => x.IsAlive));

            var pairs = pairFormation.FormatPairs(mutation.AllDesignPoints);

            crossover.PopulationNumber = mutation.PopulationNumber;
            crossover.PopulationId = mutation.PopulationId;

            var crossovered = crossover.Crossover(pairs);
            listOfSecond = crossovered;
            listOfAllDesignPoints.AddRange(crossovered);

            return crossovered;
        }

        #endregion
    }
}
