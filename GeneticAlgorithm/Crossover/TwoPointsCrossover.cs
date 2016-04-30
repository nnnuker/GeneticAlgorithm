using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.PairFormation;

namespace GeneticAlgorithm.Crossover
{
    public class TwoPointsCrossover : ICrossover
    {
        #region Field
        private readonly Random random;
        private int index1;
        private int index2;
        #endregion

        #region Property

        public int PopulationNumber { get; set; }
        public int PopulationId { get; set; }

        #endregion

        #region Constructors
        public TwoPointsCrossover()
        {
            random = new Random(DateTime.Now.Millisecond);
            PopulationNumber = 1;
            PopulationId = 1;
        }

        public TwoPointsCrossover(int index1, int index2) : this()
        {
            if (index1 < 1)
                throw new ArgumentException();
            if (index2 < 1 || index2 < index1)
                throw new ArgumentException(nameof(index2));

            this.index1 = index1;
            this.index2 = index2;
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

            while (index2 <= index1)
            {
                index1 = random.Next(2, pair.First.X1X2.Count() - 1);
                index2 = random.Next(2, pair.First.X1X2.Count() - 1);
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
            PopulationId++;

            var firstBinary = first.X1X2.ToList();
            var secondBinary = second.X1X2.ToList();

            var crossover = new List<byte>().Concat(firstBinary.GetRange(0, index1));

            crossover = crossover.Concat(secondBinary.GetRange(index1, index2 - index1));

            crossover = crossover.Concat(first.X1X2.ToList().GetRange(index2, firstBinary.Count - index2));

            newDesignPointFirst.Update(crossover);
            return newDesignPointFirst;
        }
        #endregion
    }
}
