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

        public IEnumerable<IDesignPoint> Mutate(IEnumerable<IDesignPoint> designPoints)
        {
            if (designPoints == null)
                throw new ArgumentException();

            var maxValueRnd = 101;

            var result = new List<IDesignPoint>();

            foreach (var itemDP in designPoints)
            {
                var newDesignPoint = itemDP.Clone();
                var newBinary = new List<byte>();

                foreach (var itemBianry in newDesignPoint.X1X2)
                {
                    var comparerCoefficient = rnd.Next(0, maxValueRnd);

                    if (comparerCoefficient <= mutationCoefficient)
                    {
                        if (itemBianry == 0)
                            newBinary.Add(1);
                        else
                            newBinary.Add(0);
                    }
                    else
                    {
                        newBinary.Add(itemBianry);
                    }
                }
                newDesignPoint.Update(newBinary);
                result.Add(newDesignPoint);
            }
            return result;
        }
    }
}