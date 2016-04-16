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
    public class MutationCrossover : IDescendants
    {
        private readonly ICrossover crossover;
        private readonly IMutation mutation;
        private readonly IPairFormation pairFormation;

        public MutationCrossover()
        {
            
        }

        public MutationCrossover(ICrossover crossover, IMutation mutation, IPairFormation pairFormation)
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
            var mutated = mutation.Mutate(designPoints);

            var pairs = pairFormation.FormatPairs(mutated);

            return crossover.Crossover(pairs); 
        }
    }
}
