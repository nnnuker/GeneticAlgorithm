using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.FactoryPoint;

namespace GeneticAlgorithm.Population
{
    public class RandomPopulation : IPopulation
    {
        private readonly Random random;

        public RandomPopulation()
        {
            random = new Random(DateTime.Today.Millisecond);
        }

        public IEnumerable<IDesignPoint> GetPopulation(IFactoryPoints factoryPoint, int N, IFuncCalculator funcCalculator, int populationNumber = 1, params IChromosome[] chromosomes)
        {
            var list = new List<IDesignPoint>();
            for (int i = 0; i < N; i++)
            {
                var chromo = new IChromosome[chromosomes.Count()];
                for (int j = 0; j < chromosomes.Count(); j++)
                {
                    chromo[j] = chromosomes[j].Clone();
                    double value;
                    do
                    {
                        value = random.Next((int)chromosomes[j].Left, (int)chromosomes[j].Right + 1) + random.NextDouble();
                        value = Math.Round(value, chromosomes[j].Accuracy);
                    }
                    while (value < chromosomes[j].Left || value > chromosomes[j].Right);
                    chromo[j].Value = value;
                }
                list.Add(factoryPoint.CreateFactoryPoint(populationNumber, funcCalculator, chromo));
            }
            return list;
        }
    }
}
