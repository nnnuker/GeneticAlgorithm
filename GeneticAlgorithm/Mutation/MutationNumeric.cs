using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;
using System;
using System.Linq;

namespace GeneticAlgorithm.Mutation
{
    public class MutationNumeric : IMutation
    {
        private readonly double mutationCoefficient;
        private readonly Random rndCoefficient;
        private readonly Random rndNumeric;
        public int PopulationNumber { get; set; }
        public int PopulationId { get; set; }
        public List<IDesignPoint> AllDesignPoints { get; set; }
        public List<IDesignPoint> MutateDesignPoints { get; set; }

        public MutationNumeric() : this(0)
        {
        }

        public MutationNumeric(double mutationCoefficient)
        {
            this.mutationCoefficient = mutationCoefficient;
            rndCoefficient = new Random((int)(DateTime.Now.Ticks));
            rndNumeric = new Random((int)(DateTime.Now.Ticks));
            AllDesignPoints = new List<IDesignPoint>();
            MutateDesignPoints = new List<IDesignPoint>();
        }

        public void Mutate(IEnumerable<IDesignPoint> designPoints)
        {
            if (designPoints == null)
                throw new ArgumentException();

            AllDesignPoints = new List<IDesignPoint>();
            MutateDesignPoints = new List<IDesignPoint>();

            var maxValueRnd = 101;

            foreach (var itemDP in designPoints)
            {
                var comparerCoefficient = rndCoefficient.Next(0, maxValueRnd);

                if (comparerCoefficient > mutationCoefficient)
                {
                    AllDesignPoints.Add(itemDP);
                    continue;
                }

                var newDesignPoint = itemDP.Clone();
                newDesignPoint.PopulationNumber = PopulationNumber;
                newDesignPoint.ID = PopulationId;
                PopulationId++;

                var newListBinary = new List<byte>();
                var currentX = 0;

                foreach (var itemX in newDesignPoint.X1X2)
                {
                    var newNumeric = rndNumeric.Next((int)newDesignPoint.X[currentX].Left,
                        (int)newDesignPoint.X[currentX].Right + 1);

                    if (newDesignPoint.X1X2.ElementAt(1) == itemX) //костыль
                    {
                        while (newDesignPoint.X1X2.ElementAt(0) < newNumeric)
                        {
                            newNumeric = rndNumeric.Next((int)newDesignPoint.X[currentX].Left,
                                (int)newDesignPoint.X[currentX].Right + 1);
                        };
                    }

                    newListBinary.Add((byte)newNumeric);
                    currentX++;
                }

                newDesignPoint.Update(newListBinary);
                newDesignPoint.IsMutate = true;
                AllDesignPoints.Add(newDesignPoint);
                MutateDesignPoints.Add(newDesignPoint);
            }
        }
    }
}

