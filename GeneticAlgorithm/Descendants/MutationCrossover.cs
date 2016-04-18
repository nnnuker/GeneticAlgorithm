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

        #endregion

        #region Delegate

        public delegate IEnumerable<IDesignPoint> NewPopulation(IEnumerable<IDesignPoint> designPoints);

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
        }

        #endregion

        #region Public method

        public IEnumerable<IDesignPoint> GetDescendants(IEnumerable<IDesignPoint> designPoints)
        {
            return newPopulation(designPoints);
        }

        public static IEnumerable<IDesignPoint> ParentMutationCrossover(IEnumerable<IDesignPoint> designPoints)
        {
            List<IDesignPoint> list = new List<IDesignPoint>();

            var pairs = pairFormation.FormatPairs(designPoints);

            var crossovered = crossover.Crossover(pairs);

            list.AddRange(crossovered);

            list.AddRange(mutation.Mutate(crossovered));

            return list;
        }

        public static IEnumerable<IDesignPoint> ParentDescendants(IEnumerable<IDesignPoint> designPoints)
        {
            var mutated = mutation.Mutate(designPoints);

            var pairs = pairFormation.FormatPairs(mutated);

            return crossover.Crossover(pairs);
        }

        #endregion
    }
}
