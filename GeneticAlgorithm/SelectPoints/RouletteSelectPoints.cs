using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.SelectPoints
{
    public class RouletteSelectPoints : ISelectPoints
    {
        private readonly Random rand;

        public RouletteSelectPoints()
        {
            rand = new Random((int)(DateTime.Now.Ticks));
        }

        public IEnumerable<IDesignPoint> SelectPoints(int n, IEnumerable<IDesignPoint> designPoints)
        {
            if (n > designPoints.Count())
                throw new ArgumentException();

            int circle = 360;
            var listDegreeseWithIDesignPoints = CalculateDegreese.Calculate(designPoints, circle).ToList();

            var result = new List<IDesignPoint>();

            for (var i = 0; i < n; i++)
            {
                var newPoint = rand.Next(0, circle + 1);
                double currentValueDegrees = 0;

                for (var j = 0; j < listDegreeseWithIDesignPoints.Count; j++)
                {
                    currentValueDegrees += listDegreeseWithIDesignPoints[j].Degrees;
                    if (newPoint <= currentValueDegrees)
                    {
                        result.Add(listDegreeseWithIDesignPoints[j].DesignPoint);
                        listDegreeseWithIDesignPoints.RemoveAt(j);
                        var newDesignPoints = GetIEnumerableIDesignPoint(listDegreeseWithIDesignPoints);
                        listDegreeseWithIDesignPoints = CalculateDegreese.Calculate(newDesignPoints, circle).ToList();
                        break;
                    }
                }
            }
            return result;
        }

        private IEnumerable<IDesignPoint> GetIEnumerableIDesignPoint (IEnumerable<DegreesWithIDesignPoint> listDegreeseWithIDesignPoints)
        {
            return listDegreeseWithIDesignPoints.Select(item => item.DesignPoint).ToList();
        }
    }
}
