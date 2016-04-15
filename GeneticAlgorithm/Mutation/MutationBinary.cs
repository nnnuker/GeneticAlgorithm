using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;
using System;
using GeneticAlgorithm.Chromosome;

namespace GeneticAlgorithm.Mutation
{
    public class MutationBinary : IMutation
    {
        private double mutationCoefficient;
        private Random rnd;

        public MutationBinary() : this(0)
        {

        }

        public MutationBinary(double mutationCoefficient)
        {
            this.mutationCoefficient = mutationCoefficient;
            rnd = new Random(DateTime.Today.Millisecond);
        }

        public IEnumerable<IDesignPoint> Mutate(IEnumerable<IDesignPoint> designPoints)
        {
            if (designPoints == null)
                throw new ArgumentException();

            var maxValueRnd = 101;

            var result = new List<IDesignPoint>();

            foreach (var itemDP in designPoints)
            {
                var newDesignPoint = itemDP.Clone();
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
                            if (itemOldBinary == 0)
                                newBinary.Add(1);
                            else
                                newBinary.Add(0);
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
                result.Add(newDesignPoint);
            }
            return result;
        }
    }
}