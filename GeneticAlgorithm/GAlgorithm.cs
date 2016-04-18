using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Descendants;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Population;
using GeneticAlgorithm.SelectPoints;

namespace GeneticAlgorithm
{
    public class GAlgorithm
    {
        #region Fields

        private readonly int end;
        private readonly int n;
        private readonly IDescendants descendants;
        private IPopulation population;
        private readonly ISelectPoints selectPoints;
        private readonly List<IDesignPoint> listOfAllDesignPoints;
        private List<IDesignPoint> listOfCurrentDesignPoints;
        private int populationNumber;

        #endregion

        #region Property

        public IEnumerable<IDesignPoint> ListOfAllDesignPoints => listOfAllDesignPoints;

        #endregion

        #region Constructors

        public GAlgorithm() : this(0, 0, null, null, null)
        {

        }

        public GAlgorithm(int end, int n, IPopulation population, ISelectPoints selectPoints,
            IDescendants descendants)
        {
            if (descendants == null || population == null || selectPoints == null)
                throw new ArgumentNullException();

            this.end = end;
            this.n = n;
            this.descendants = descendants;
            this.population = population;
            this.selectPoints = selectPoints;
            this.listOfAllDesignPoints = listOfCurrentDesignPoints = population.GetPopulation().ToList();
        }

        #endregion

        #region Public methods

        public void MoveNext()
        {
            listOfCurrentDesignPoints = listOfCurrentDesignPoints.Where(x => x.IsAlive).ToList();

            var percent = (int)Math.Round(((double)listOfCurrentDesignPoints.Count * (double)n) / 100.0);

            listOfCurrentDesignPoints = selectPoints.SelectPoints(percent, listOfCurrentDesignPoints).ToList();

            listOfCurrentDesignPoints = descendants.GetDescendants(listOfCurrentDesignPoints).ToList();

            listOfAllDesignPoints.AddRange(listOfCurrentDesignPoints);

            populationNumber++;
        }

        public void MoveToEnd()
        {
            for (var i = populationNumber; i < end; i++)
            {
                MoveNext();
            }
        }

        #endregion

    }
}
