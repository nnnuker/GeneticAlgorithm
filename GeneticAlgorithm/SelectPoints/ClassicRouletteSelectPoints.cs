using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.SelectPoints
{
    public class ClassicRouletteSelectPoints : ISelectPoints
    {
        #region Fields

        private readonly Random rand;

        #endregion

        #region Constructors

        public ClassicRouletteSelectPoints()
        {
            rand = new Random((int) (DateTime.Now.Ticks));
        }

        #endregion

        #region Public methods

        public IEnumerable<IDesignPoint> SelectPoints(int n, IEnumerable<IDesignPoint> designPoints)
        {
            if (n > designPoints.Count())
                throw new ArgumentException();

            var circle = 360;
            var listDegreeseWithIDesignPoints = CalculateDegreese.Calculate(designPoints, circle);

            var result = new List<IDesignPoint>();

            for (var i = 0; i < n; i++)
            {
                var newPoint = rand.Next(0, circle + 1);
                double currentValueDegrees = 0;

                foreach (var item in listDegreeseWithIDesignPoints)
                {
                    currentValueDegrees += item.Degrees;
                    if (newPoint <= currentValueDegrees)
                    {
                        result.Add(item.DesignPoint);
                        break;
                    }
                }
            }
            return result;
        }

        #endregion

    }
}
