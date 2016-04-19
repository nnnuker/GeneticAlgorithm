using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;
using System;
using System.Linq;
using GeneticAlgorithm.Chromosome;

namespace GeneticAlgorithm.Mutation
{
    public class MutationBinary : IMutation
    {
        private readonly double mutationCoefficient;
        private readonly Random rnd;
        public int PopulationNumber { get; set; } = 1;
        public List<IDesignPoint> AllDesignPoints { get; set; }
        public List<IDesignPoint> MutateDesignPoints { get; set; }

        public MutationBinary() : this(0)
        {

        }

        public MutationBinary(double mutationCoefficient)
        {
            this.mutationCoefficient = mutationCoefficient;
            rnd = new Random(DateTime.Today.Millisecond);
            AllDesignPoints = new List<IDesignPoint>();
            MutateDesignPoints = new List<IDesignPoint>();
        }
        
        public void Mutate(IEnumerable<IDesignPoint> designPoints)
        {
            if (designPoints == null)
                throw new ArgumentException();

            var maxValueRnd = 101;

            foreach (var itemDP in designPoints)
            {
                var comparerCoefficient = rnd.Next(0, maxValueRnd);

                if (comparerCoefficient <= mutationCoefficient)
                {
                    var newDesignPoint = itemDP.Clone();
                    newDesignPoint.PopulationNumber = PopulationNumber;

                    var newListBinary = new List<byte>();

                    foreach (var itemX in newDesignPoint.X1X2)
                    {
                        newListBinary.Add(itemX != 0 ? (byte) 0 : (byte) 1);
                    }

                    newDesignPoint.Update(newListBinary);
                    newDesignPoint.IsMutate = true;
                    AllDesignPoints.Add(newDesignPoint);
                    MutateDesignPoints.Add(newDesignPoint);
                }
                else
                {
                    AllDesignPoints.Add(itemDP);
                }
            }
        }
    }
}