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
        private readonly ICrossover crossover;
        private readonly IMutation mutation;
        private readonly IPairFormation pairFormation;

        public CrossoverMutation()
        {
            
        }

        public CrossoverMutation(ICrossover crossover, IMutation mutation, IPairFormation pairFormation)
        {
            if (crossover == null) throw new ArgumentNullException(nameof(crossover));
            if (mutation == null) throw new ArgumentNullException(nameof(mutation));
            if (pairFormation == null) throw new ArgumentNullException(nameof(pairFormation));
            this.crossover = crossover;
            this.mutation = mutation;
            this.pairFormation = pairFormation;
        }

        public IEnumerable<IDesignPoint> GetDescendants(IEnumerable<IDesignPoint> designPoints)
        {
            var pairs = pairFormation.FormatPairs(designPoints);

            var crossovered = crossover.Crossover(pairs);

            return mutation.Mutate(crossovered);
        }
    }
}
