using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.Population
{
    public class RandomPopulation : IPopulation
    {
        private Random random;

        public RandomPopulation()
        {
            random = new Random(DateTime.Today.Millisecond);
        }

        public IEnumerable<IDesignPoint> GetPopulation(int N, int accuracy, string funcExpression, params IChromosome[] chromosomes)
        {
            var list = new List<DesignPoint>();
            for (int i = 0; i < N; i++)
            {
                IChromosome[] chromo = new Chromosome.Chromosome[chromosomes.Count()];
                for (int j = 0; j < chromosomes.Count(); j++)
                {
                    double value;
                    do
                    {
                        value = random.Next((int)chromosomes[j].Left, (int)chromosomes[j].Right + 1) + random.NextDouble();
                        value = Math.Round(value, accuracy);
                        
                    }
                    while (value < chromosomes[j].Left || value > chromosomes[j].Right);
                }
                list.Add(new DesignPoint(1, funcExpression, chromo));
            }
            return list;
        }
    }
}
