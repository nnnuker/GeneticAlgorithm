﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.SelectPoints
{
    public class ClassicRouletteSelectPoints : ISelectPoints
    {
        Random rand;

        public ClassicRouletteSelectPoints()
        {
            rand = new Random(DateTime.Today.Millisecond);
        }

        public IEnumerable<IDesignPoint> SelectPoints(int n, IEnumerable<IDesignPoint> designPoints)
        {
            if (n > designPoints.Count())
                throw new ArgumentException();

            int circle = 360;
            var listDegreeseWithIDesignPoints = CalculateDegreese.Calculate(designPoints, circle);

            var result = new List<IDesignPoint>();

            for (int i = 0; i < n; i++)
            {
                var newPoint = rand.Next(0, circle + 1);
                double currentValueDegrees = 0;

                foreach (var item in listDegreeseWithIDesignPoints)
                {
                    currentValueDegrees += item.Degreese;
                    if (newPoint <= currentValueDegrees)
                    {
                        result.Add(item.DesignPoint);
                        break;
                    }
                }
            }
            return result;
        }
    }
}
