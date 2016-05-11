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
        private List<IDesignPoint> currentDesignPoints;

        #endregion

        #region Properties

        public IEnumerable<IDesignPoint> ListOfAllDesignPoints => listOfAllDesignPoints;
        public IEnumerable<IDesignPoint> ListOfSelectedPoints { get; private set; }
        public IEnumerable<IDesignPoint> ListOfFirst { get; private set; }
        public IEnumerable<IDesignPoint> ListOfSecond { get; private set; }

        public List<IDesignPoint> CurrentDesignPoints
        {
            get { return currentDesignPoints; }
            set { currentDesignPoints = value; }
        }

        public int PopulationNumber => populationNumber;

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
            this.listOfAllDesignPoints = listOfCurrentDesignPoints 
                = currentDesignPoints = population.GetPopulation().ToList();
            this.ListOfSelectedPoints = new List<IDesignPoint>();
            this.ListOfFirst = new List<IDesignPoint>();
            this.ListOfSecond = new List<IDesignPoint>();
        }

        #endregion

        #region Public methods

        public void MoveNext()
        {
            listOfCurrentDesignPoints = listOfCurrentDesignPoints.Where(x => x.IsAlive).ToList();

            var percent = (int)Math.Floor(((double)listOfCurrentDesignPoints.Count * (double)n) / 100.0);

            listOfCurrentDesignPoints = selectPoints.SelectPoints(percent, listOfCurrentDesignPoints).ToList();

            ListOfSelectedPoints = listOfCurrentDesignPoints;

            listOfCurrentDesignPoints = descendants.GetDescendants(listOfCurrentDesignPoints).ToList();
            ListOfFirst = descendants.GetAfterFirst;
            ListOfSecond = descendants.GetAfterSecond;

            currentDesignPoints = descendants.GetAllDesignPoints.ToList();

            listOfAllDesignPoints.AddRange(currentDesignPoints);

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
