using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FactoryPoint;

namespace GeneticAlgorithm.Population
{
    public class RandomPopulation : IPopulation
    {
        private readonly Random random;
        private readonly IFactoryPoints factoryPoint;
        private readonly int N;
        private readonly int populationNumber;
        private readonly IChromosome[] chromosomes;

        public RandomPopulation()
        {
            random = new Random((int)DateTime.Now.Ticks);
        }

        public RandomPopulation(IFactoryPoints factoryPoint, int N, int populationNumber = 1, params IChromosome[] chromosomes):this()
        {
            this.factoryPoint = factoryPoint;
            this.N = N;
            this.populationNumber = populationNumber;
            this.chromosomes = chromosomes;
        }

        public IEnumerable<IDesignPoint> GetPopulation()
        {
            int id = 1;
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
                list.Add(factoryPoint.CreateFactoryPoint(populationNumber, id, chromo));
                id++;
            }
            return list;
        }
    }
}
