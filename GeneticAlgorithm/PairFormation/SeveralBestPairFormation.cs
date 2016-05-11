using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.PairFormation
{
    public class SeveralBestPairFormation : IPairFormation
    {
        public IEnumerable<IPair> FormatPairs(IEnumerable<IDesignPoint> designPoints)
        {
            var result = new List<IPair>();

            var list = designPoints.OrderBy(x => x.FunctionValue).ToList();

            while (list.Count - 1 > 0)
            {
                result.Add(new Pair
                {
                    First = list[0],
                    Second = list[1]
                });

                list.RemoveAt(0);
                list.RemoveAt(0);
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
