using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Crossover;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Mutation;
using GeneticAlgorithm.PairFormation;

namespace GeneticAlgorithm.Descendants
{
    public class CrossoverMutationDesc : IDescendants
    {
        #region Fields

        private readonly ICrossover crossover;
        private readonly IMutation mutation;
        private readonly IPairFormation pairFormation;
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

        public CrossoverMutationDesc() : this(null, null, null)
        {
        }

        public CrossoverMutationDesc(ICrossover crossover, IMutation mutation, IPairFormation pairFormation)
        {
            if (crossover == null) throw new ArgumentNullException(nameof(crossover));
            if (mutation == null) throw new ArgumentNullException(nameof(mutation));
            if (pairFormation == null) throw new ArgumentNullException(nameof(pairFormation));

            this.crossover = crossover;
            this.mutation = mutation;
            this.pairFormation = pairFormation;
            listOfAllDesignPoints = new List<IDesignPoint>();
            listOfFirst = new List<IDesignPoint>();
            listOfSecond = new List<IDesignPoint>();
        }

        #endregion

        #region Public methods

        public IEnumerable<IDesignPoint> GetDescendants(IEnumerable<IDesignPoint> designPoints)
        {
            listOfAllDesignPoints = new List<IDesignPoint>();
            return ParentDescendants(designPoints);
        }
        #endregion

        #region Private methods

        private IEnumerable<IDesignPoint> ParentDescendants(IEnumerable<IDesignPoint> designPoints)
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