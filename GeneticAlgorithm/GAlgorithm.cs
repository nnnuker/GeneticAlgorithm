using System;
using System.Collections.Generic;
using GeneticAlgorithm.Descendants;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.PairFormation;
using GeneticAlgorithm.Population;
using GeneticAlgorithm.SelectPoints;

namespace GeneticAlgorithm
{
    public class GAlgorithm
    {
        #region Fields

        IDescendants descendants;
        IPopulation population;
        ISelectPoints selectPoints;
        private readonly IEnumerable<IDesignPoint> listDesignPoints;
        private NewPopulation newPopulation;

        #endregion

        #region Delegate

        public delegate void NewPopulation();

        #endregion

        #region Property

        public IEnumerable<IDesignPoint> ListDesignPoints => listDesignPoints;

        #endregion

        #region Constructors

        public GAlgorithm() : this(null, null, null, null)
        {

        }

        public GAlgorithm(IPopulation population, ISelectPoints selectPoints,
            IDescendants descendants, NewPopulation newPopulation)
        {
            if (descendants == null || population == null || selectPoints == null || newPopulation == null)
                throw new ArgumentNullException();

            this.descendants = descendants;
            this.population = population;
            this.selectPoints = selectPoints;
            this.newPopulation = newPopulation;
            this.listDesignPoints = population.GetPopulation();
        }

        #endregion

        #region Public methods

        public void MoveNext()
        {
            throw new NotImplementedException();
        }

        public void MoveToEnd()
        {
            throw new NotImplementedException();
        }

        public void ParentMutationCrossover()
        {
            throw new NotImplementedException();
        }

        public void ParentDescendants()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private methods


        #endregion

    }
}
