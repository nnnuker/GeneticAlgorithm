using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.PairFormation
{
    public class BestWorsePairFormation : IPairFormation
    {
        public IEnumerable<IPair> FormatPairs(IEnumerable<IDesignPoint> designPoints)
        {
            var result = new List<IPair>();

            var list = designPoints.OrderBy(x => x.FunctionValue).ToList();

            while (list.Count - 1 > 0)
            {
                result.Add(new Pair
                {
                    First = list.First(),
                    Second = list.Last()
                });

                list.RemoveAt(0);
                list.RemoveAt(list.Count - 1);
            }

            if (list.Count == 1)
            {
                result.Add(new Pair
                {
                    First = list.First(),
                    Second = null
                });
            }

            return result;
        }
    }
}
