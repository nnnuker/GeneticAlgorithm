using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;
using System.Linq;
using System;

namespace GeneticAlgorithm.PairFormation
{
    public class RandomPairFormation : IPairFormation
    {
        Random random;
        List<int> usedNumbers;

        public RandomPairFormation()
        {
            random = new Random(DateTime.Now.Millisecond);
            usedNumbers = new List<int>();
        }

        public IEnumerable<IPair> FormatPairs(IEnumerable<IDesignPoint> designPoints)
        {
            var pairs = new List<IPair>();
            var count = designPoints.Count();

            int first, second;

            for (int i = 0; i < count/2; i++)
            {
                do
                {
                    first = random.Next(count);
                }
                while (CheckNumber(first));

                usedNumbers.Add(first);

                do
                {
                    second = random.Next(count);
                }
                while (CheckNumber(second));

                usedNumbers.Add(second);
                pairs.Add(new Pair { First = designPoints.ElementAt(first), Second = designPoints.ElementAt(second) });
            }
            
            if (count % 2 != 0)
            {
                var i = 0;

                foreach (var usedNumber in usedNumbers)
                {
                   if (i != usedNumber)
                        pairs.Add(new Pair { First = designPoints.ElementAt(i), Second = null });
                }
            }

            return pairs;

        }

        private bool CheckNumber(int number)
        {
            foreach (var usedNumber in usedNumbers)
            {
                if (number == usedNumber)
                    return false;
            }
            return true;
        }
    }
}
