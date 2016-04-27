using System;
using System.Collections.Generic;
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

        #endregion

        #region Delegate

        public delegate IEnumerable<IDesignPoint> NewPopulation(IEnumerable<IDesignPoint> designPoints);

        #endregion

        #region Property

        public IEnumerable<IDesignPoint> GetAllDesignPoints => listOfAllDesignPoints;

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

            mutation.Mutate(designPoints);

            list.AddRange(mutation.AllDesignPoints);

            var pairs = pairFormation.FormatPairs(list);

            crossover.PopulationNumber = mutation.PopulationNumber;

            var crossovered = crossover.Crossover(pairs);

            list.AddRange(crossovered);

            listOfAllDesignPoints.AddRange(list);

            return list;
        }

        public static IEnumerable<IDesignPoint> ParentDescendants(IEnumerable<IDesignPoint> designPoints)
        {
            mutation.PopulationNumber++;

            mutation.Mutate(designPoints);

            listOfAllDesignPoints.AddRange(mutation.AllDesignPoints);

            var pairs = pairFormation.FormatPairs(mutation.AllDesignPoints);

            crossover.PopulationNumber = mutation.PopulationNumber;

            var crossovered = crossover.Crossover(pairs);

            listOfAllDesignPoints.AddRange(crossovered);

            return crossovered;
        }

        #endregion
    }
}
