using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.SelectPoints
{
    public class BestSelectPoints : ISelectPoints
    {
        public IEnumerable<IDesignPoint> SelectPoints(int n, IEnumerable<IDesignPoint> designPoints)
        {
            if (designPoints == null) throw new ArgumentNullException(nameof(designPoints));
            if (n > designPoints.Count()) throw new ArgumentOutOfRangeException(nameof(n));

            return designPoints.OrderBy(x => x.FunctionValue).Take(n);
        }
    }
}
