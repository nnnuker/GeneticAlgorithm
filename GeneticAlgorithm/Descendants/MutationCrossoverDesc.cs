using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Crossover;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Mutation;
using GeneticAlgorithm.PairFormation;

namespace GeneticAlgorithm.Descendants
{
    public class MutationCrossoverDesc : IDescendants
    {
        #region Fields

        private readonly ICrossover crossover;
        private readonly IMutation mutation;
        private readonly IPairFormation pairFormation;
        private List<IDesignPoint> listOfAllDesignPoints;
        private IEnumerable<IDesignPoint> listOfSecond;
        private IEnumerable<IDesignPoint> listOfFirst;

        #endregion

        #region Property

        public IEnumerable<IDesignPoint> GetAllDesignPoints => listOfAllDesignPoints;
        public IEnumerable<IDesignPoint> GetAfterFirst => listOfFirst;
        public IEnumerable<IDesignPoint> GetAfterSecond => listOfSecond;

        #endregion

        #region Constructors

        public MutationCrossoverDesc() : this(null, null, null)
        {
        }

        public MutationCrossoverDesc(ICrossover crossover, IMutation mutation, IPairFormation pairFormation)
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

        #region Public method

        public IEnumerable<IDesignPoint> GetDescendants(IEnumerable<IDesignPoint> designPoints)
        {
            listOfAllDesignPoints = new List<IDesignPoint>();
            return ParentDescendants(designPoints);
        }
        #endregion

        #region Private methods

        private IEnumerable<IDesignPoint> ParentDescendants(IEnumerable<IDesignPoint> designPoints)
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