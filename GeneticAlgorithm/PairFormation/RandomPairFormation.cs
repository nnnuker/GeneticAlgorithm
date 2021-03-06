﻿using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;
using System.Linq;
using System;

namespace GeneticAlgorithm.PairFormation
{
    public class RandomPairFormation : IPairFormation
    {
        #region Field
        private readonly Random random;
        #endregion

        #region Constructor
        public RandomPairFormation()
        {
            random = new Random((int)(DateTime.Now.Ticks));
        }
        #endregion  

        #region Public methods
        public IEnumerable<IPair> FormatPairs(IEnumerable<IDesignPoint> designPoints)
        {
            var usedNumbers = new List<int>();
            if (designPoints == null)
                throw new ArgumentNullException();
            
            var pairs = new List<IPair>();
            var count = designPoints.Count();

            int first, second;

            for (int i = 0; i < count / 2; i++)
            {
                do
                {
                    first = random.Next(count);
                }
                while (usedNumbers.Contains(first));
                usedNumbers.Add(first);

                do
                {
                    second = random.Next(count);
                }
                while (usedNumbers.Contains(second));
                usedNumbers.Add(second);

                pairs.Add(new Pair { First = designPoints.ElementAt(first), Second = designPoints.ElementAt(second) });
            }

            if (count % 2 != 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (!usedNumbers.Contains(i))
                        pairs.Add(new Pair { First = designPoints.ElementAt(i), Second = null });
                }
            }

            return pairs;
        }
        #endregion
    }
}
