using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.PairFormation;

namespace GeneticAlgorithm.Crossover
{
    public class OnePointCrossover : ICrossover
    {
        #region Field
        private readonly Random random;
        private int index;
        #endregion

        public int PopulationNumber { get; set; }
        public int PopulationId { get; set; }

        #region Constructor
        public OnePointCrossover()
        {
            random = new Random(DateTime.Now.Millisecond);
            PopulationNumber = 1;
            PopulationId = 1;
        }

        public OnePointCrossover(int index): this()
        {
            if (index < 1)            
                throw new ArgumentException();
        
            this.index = index;
        }
        #endregion  

        #region Public methods
        public IEnumerable<IDesignPoint> Crossover(IEnumerable<IPair> pairs)
        {
            if (pairs == null)
                throw new ArgumentNullException();
            var result = new List<IDesignPoint>();

            foreach (var item in pairs)
            {
                var itemDesignPoints = Crossover(item);
                result.AddRange(itemDesignPoints);
            }
            return result;
        }

        public IEnumerable<IDesignPoint> Crossover(IPair pair)
        {
            if (pair == null)
                throw new ArgumentNullException();

            var result = new List<IDesignPoint>();

            if (pair.Second == null)
            {
                result.Add(pair.First.Clone());
                return result;
            }

            if (index < 2 || index > pair.First.X1X2.Count() - 1)
            {
                index = random.Next(2, pair.First.X1X2.Count() - 1);
            }
            
            var newDesignPointFirst = CrossoverDesignPoints(pair.First, pair.Second);
            result.Add(newDesignPointFirst);

            var newDesignPointSecond = CrossoverDesignPoints(pair.Second, pair.First);
            result.Add(newDesignPointSecond);

            return result;
        }
        #endregion

        #region Private method
        private IDesignPoint CrossoverDesignPoints(IDesignPoint first, IDesignPoint second)
        {
            var newDesignPointFirst = first.Clone();
            newDesignPointFirst.PopulationNumber = PopulationNumber;
            newDesignPointFirst.ID = PopulationId;
            newDesignPointFirst.IsMutate = false;

            PopulationId++;

            var crossoverFirst = new List<byte>().Concat(first.X1X2.ToList().GetRange(0, index));
            crossoverFirst = crossoverFirst.Concat(second.X1X2.ToList().GetRange(index, second.X1X2.Count() - index));
            newDesignPointFirst.Update(crossoverFirst);
            return newDesignPointFirst;
        }
        #endregion
    }
}
