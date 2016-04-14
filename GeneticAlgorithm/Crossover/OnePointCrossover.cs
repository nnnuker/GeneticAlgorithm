using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.PairFormation;
using GeneticAlgorithm.Chromosome;

namespace GeneticAlgorithm.Crossover
{
    public class OnePointCrossover : ICrossover
    {
        #region Field
        private readonly Random random;
        private int index;
        #endregion

        #region Constructor
        public OnePointCrossover()
        {
            random = new Random(DateTime.Now.Millisecond);
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

            var binaryFirstPair = pair.First.X1X2.ToList();
            var binarySecondPair = pair.Second.X1X2.ToList();

            index = random.Next(2, pair.First.X1X2.Count() - 2);

            var newDesignPointFirst = pair.First.Clone();
            var crossoverFirst = new List<byte>().Concat(binaryFirstPair.GetRange(0, index));
            crossoverFirst.Concat(binarySecondPair.GetRange(index, pair.First.X1X2.Count()));
            newDesignPointFirst.Update(crossoverFirst);
            result.Add(newDesignPointFirst);

            var newDesignPointSecond = pair.First.Clone();
            var crossoverSecond = new List<byte>().Concat(binarySecondPair.GetRange(0, index));
            crossoverFirst.Concat(binaryFirstPair.GetRange(index, pair.First.X1X2.Count()));
            newDesignPointSecond.Update(crossoverSecond);
            result.Add(newDesignPointSecond);

            return result;
        }
        #endregion
    }
}
