using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;
using System;
using GeneticAlgorithm.Chromosome;

namespace GeneticAlgorithm.Mutation
{
    public class MutationBinary : IMutation
    {
        private readonly double mutationCoefficient;
        private readonly Random rnd;

        public MutationBinary() : this(0)
        {

        }

        public MutationBinary(double mutationCoefficient)
        {
            this.mutationCoefficient = mutationCoefficient;
            rnd = new Random(DateTime.Today.Millisecond);
        }

        public int PopulationNumber { get; set; } = 1;

        public IEnumerable<IDesignPoint> Mutate(IEnumerable<IDesignPoint> designPoints)
        {
            if (designPoints == null)
                throw new ArgumentException();

            var maxValueRnd = 101;

            var result = new List<IDesignPoint>();

            foreach (var itemDP in designPoints)
            {
                var newDesignPoint = itemDP.Clone();
                newDesignPoint.PopulationNumber = PopulationNumber;
                var newListChromosome = new List<IChromosome>();

                foreach (var itemX in newDesignPoint.X)
                {
                    var newChomosome = itemX.Clone();
                    var oldBinary = newChomosome.Binary;
                    var newBinary = new List<byte>();

                    foreach (var itemOldBinary in oldBinary)
                    {
                        var comparerCoefficient = rnd.Next(0, maxValueRnd);

                        if (comparerCoefficient <= mutationCoefficient)
                        {
                            newBinary.Add(itemOldBinary != 0 ? (byte)0 : (byte)1);
                        }
                        else
                        {
                            newBinary.Add(itemOldBinary);
                        }
                    }
                    newChomosome.Update(newBinary);
                    newListChromosome.Add(newChomosome);
                }
                newDesignPoint.X = newListChromosome;
                newDesignPoint.FunctionValue = newDesignPoint.FuncCalculator.CalculateFunc(newListChromosome.ToArray());
                result.Add(newDesignPoint);
            }
            return result;
        }
    }
}