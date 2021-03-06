﻿using System;
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

        public MutationCrossover() : this(null, null, null)
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
            listOfAllDesignPoints = new List<IDesignPoint>();
            listOfFirst = new List<IDesignPoint>();
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
        #endregion
    }
}
