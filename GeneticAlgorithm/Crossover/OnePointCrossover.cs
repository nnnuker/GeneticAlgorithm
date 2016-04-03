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
        private Random random;
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

            var result = new List<DesignPoint>();

            if (pair.Second == null)
            {
                result.Add((DesignPoint)pair.First.Copy());
                return result;
            }

            var binaryFirstPair = pair.First.X1X2;
            var bunarySecondPair = pair.Second.X1X2;

            index = random.Next(2, pair.First.X1X2.Length - 2);

            var newDesignPointFirst = pair.First.Copy();
            var crossoverFirst = string.Concat(binaryFirstPair.Substring(0, index), bunarySecondPair.Substring(index));
            newDesignPointFirst.Update(crossoverFirst);
            result.Add((DesignPoint)newDesignPointFirst);

            var newDesignPointSecond = pair.First.Copy();
            var crossoverSecond = string.Concat(bunarySecondPair.Substring(0, index), binaryFirstPair.Substring(index));
            newDesignPointSecond.Update(crossoverSecond);
            result.Add((DesignPoint)newDesignPointSecond);

            return result;
        }
        #endregion
    }
}
