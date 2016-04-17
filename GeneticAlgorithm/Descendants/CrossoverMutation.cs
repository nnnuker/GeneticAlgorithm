using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #endregion

        #region Delegate

        public delegate IEnumerable<IDesignPoint> NewPopulation(IEnumerable<IDesignPoint> designPoints);

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
            var pairs = pairFormation.FormatPairs(designPoints);

            var crossovered = crossover.Crossover(pairs);

            return mutation.Mutate(crossovered);
        }

        #endregion

    }
}
