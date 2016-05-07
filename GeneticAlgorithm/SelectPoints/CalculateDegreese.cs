using System;
using GeneticAlgorithm.DesignPoints;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm.SelectPoints
{
    class ComparerIDesignPoints : IComparer<IDesignPoint>
    {
        public int Compare(IDesignPoint x, IDesignPoint y)
        {
            return x.FunctionValue > y.FunctionValue ? 1 : x.FunctionValue < y.FunctionValue ? -1 : 0;
        }
    }

    static class CalculateDegreese
    {
        public static IEnumerable<DegreesWithIDesignPoint> Calculate(IEnumerable<IDesignPoint> designPoints, int circle)
        {
            var listDesignPoints = designPoints.ToList();
            listDesignPoints.Sort(new ComparerIDesignPoints());
            listDesignPoints.Reverse();

            var sumFunctionValue = designPoints.Sum(item => Math.Abs(item.FunctionValue));

            var listDegrees = new List<double>();
            foreach (var item in listDesignPoints)
            {
                listDegrees.Add(Math.Abs(item.FunctionValue) * circle / sumFunctionValue);
            }
            listDegrees.Reverse();

            var listDegreesWithIDesignPoint = new List<DegreesWithIDesignPoint>();
            for (int i = 0; i < designPoints.Count(); i++)
            {
                listDegreesWithIDesignPoint.Add(new DegreesWithIDesignPoint(listDesignPoints[i], listDegrees[i]));
            }

            return listDegreesWithIDesignPoint;

        }
    }
}
