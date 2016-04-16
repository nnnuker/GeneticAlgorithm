using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;
using System;

namespace GeneticAlgorithm.Mutation
{
    public class MutationNumeric : IMutation
    {
        private readonly double mutationCoefficient;
        private readonly Random rndCoefficient;
        private readonly Random rndNumeric;

        public MutationNumeric() : this(0)
        {

        }

        public MutationNumeric(double mutationCoefficient)
        {
            this.mutationCoefficient = mutationCoefficient;
            rndCoefficient = new Random(DateTime.Today.Millisecond);
            rndNumeric = new Random(DateTime.Today.Millisecond);
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
                var currentX = 0;

                foreach (var itemBianry in newDesignPoint.X1X2)
                {
                    var comparerCoefficient = rndCoefficient.Next(0, maxValueRnd);

                    if (comparerCoefficient <= mutationCoefficient)
                    {
                        var newNumeric = rndNumeric.Next((int)newDesignPoint.X[currentX].Left, (int)newDesignPoint.X[currentX].Right + 1);
                        newBinary.Add((byte)newNumeric);
                    }
                    else
                    {
                        newBinary.Add(itemBianry);
                    }
                    currentX++;
                }
                newDesignPoint.Update(newBinary);
                result.Add(newDesignPoint);
            }
            return result;
        }
    }
}