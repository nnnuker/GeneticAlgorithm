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

        private ICrossover crossover;
        private IMutation mutation;
        private IPairFormation pairFormation;
        private List<IDesignPoint> listOfAllDesignPoints;
        private IEnumerable<IDesignPoint> listOfSecond;
        private IEnumerable<IDesignPoint> listOfFirst;

        #endregion

        #region Properties

        public IEnumerable<IDesignPoint> GetAllDesignPoints => listOfAllDesignPoints;
        public IEnumerable<IDesignPoint> GetAfterFirst => listOfFirst;
        public IEnumerable<IDesignPoint> GetAfterSecond => listOfSecond;

        #endregion

        #region Constructors

        public CrossoverMutation() : this(null, null, null)
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
            listOfAllDesignPoints = new List<IDesignPoint>();
            listOfFirst= new List<IDesignPoint>();
            listOfSecond = new List<IDesignPoint>();
        }

        #endregion

        #region Public method

        public IEnumerable<IDesignPoint> GetDescendants(IEnumerable<IDesignPoint> designPoints)
        {
            listOfAllDesignPoints = new List<IDesignPoint>();
            return ParentMutationCrossover(designPoints);
        }
        #endregion

        #region Private methods

        private IEnumerable<IDesignPoint> ParentMutationCrossover(IEnumerable<IDesignPoint> designPoints)
        {
            var list = new List<IDesignPoint>();

            var pairs = pairFormation.FormatPairs(designPoints);

            crossover.PopulationNumber++;
            crossover.PopulationId = 1;

            var crossovered = crossover.Crossover(pairs);

            listOfFirst = crossovered;

            list.AddRange(crossovered.Where(x => x.IsAlive));

            mutation.PopulationNumber = crossover.PopulationNumber;
            mutation.PopulationId = crossover.PopulationId;

            mutation.Mutate(crossovered);

            listOfSecond = mutation.MutateDesignPoints;

            list.AddRange(mutation.MutateDesignPoints);

            listOfAllDesignPoints = list;

            return list;
        }

        #endregion

        
    }
}
