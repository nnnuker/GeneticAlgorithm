using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.SelectPoints
{
    public class TourSelectPoints : ISelectPoints
    {
        #region Fields

        private readonly Random random;

        #endregion

        #region Constructors

        public TourSelectPoints()
        {
            this.random = new Random((int) DateTime.Now.Ticks);
        }

        #endregion

        #region Public methods

        public IEnumerable<IDesignPoint> SelectPoints(int n, IEnumerable<IDesignPoint> designPoints)
        {
            if (designPoints == null) throw new ArgumentNullException(nameof(designPoints));
            if (n > designPoints.Count() || n < 0) throw new ArgumentOutOfRangeException(nameof(n));

            var result = new List<IDesignPoint>();
            var count = designPoints.Count();

            while (n > 0)
            {
                var rand1 = random.Next(0, count);
                var rand2 = random.Next(0, count);

                while (rand2 == rand1)
                {
                    rand2 = random.Next(0, count);
                }

                var rand1Point = designPoints.ElementAt(rand1);
                var rand2Point = designPoints.ElementAt(rand2);

                result.Add(rand1Point.FunctionValue < rand2Point.FunctionValue ? rand1Point : rand2Point);
                n--;
            }

            return result;
        }

        #endregion

    }
}
