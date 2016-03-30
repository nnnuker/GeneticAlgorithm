using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Crossover;
using GeneticAlgorithm.Descendants;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.PairFormation;
using GeneticAlgorithm.Population;
using GeneticAlgorithm.SelectPoints;

namespace GeneticAlgorithm
{
    public class GAlgorithm
    {
        string ss = "ss!";
        ICrossover crossover;
        IDescendants descendants;
        IPairFormation pairFormation;
        IPopulation population;
        ISelectPoints selectPoints;
        private IEnumerable<IDesignPoint> listDesignPoints;
        public delegate void NewPopulation();
        private NewPopulation newPopulation;

        public IEnumerable<IDesignPoint> ListDesignPoints
        {
            get
            {
                return listDesignPoints;
            }
        }

        public GAlgorithm() : this(null, null, null, null, null, null)
        {

        }

        public GAlgorithm(IPopulation population, ISelectPoints selectPoints, IPairFormation pairFormation, ICrossover crossover,
            IDescendants descendants, NewPopulation newPopulation)
        {
            if (crossover == null || descendants == null || pairFormation == null || population == null || selectPoints == null)
                throw new ArgumentNullException();

            this.crossover = crossover;
            this.descendants = descendants;
            this.pairFormation = pairFormation;
            this.population = population;
            this.selectPoints = selectPoints;
            this.listDesignPoints = new List<IDesignPoint>();
            this.newPopulation = newPopulation;
        }

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
    }
}
