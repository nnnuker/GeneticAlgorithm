using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;
using System;
using System.Linq;

namespace GeneticAlgorithm.Mutation
{
    public class MutationBinary : IMutation
    {
        private readonly double mutationCoefficient;
        private readonly Random rnd;
        public int PopulationNumber { get; set; } = 1;
        public int PopulationId { get; set; }
        public List<IDesignPoint> AllDesignPoints { get; set; }
        public List<IDesignPoint> MutateDesignPoints { get; set; }

        public MutationBinary() : this(0)
        {

        }

        public MutationBinary(double mutationCoefficient)
        {
            this.mutationCoefficient = mutationCoefficient;
            rnd = new Random((int)DateTime.Now.Ticks);
            AllDesignPoints = new List<IDesignPoint>();
            MutateDesignPoints = new List<IDesignPoint>();
        }
        
        public void Mutate(IEnumerable<IDesignPoint> designPoints)
        {
            if (designPoints == null)
                throw new ArgumentException();

            AllDesignPoints = new List<IDesignPoint>();
            MutateDesignPoints = new List<IDesignPoint>();

            int maxValueRnd = 101;

            foreach (var itemDP in designPoints)
            {
                var comparerCoefficient = rnd.Next(0, maxValueRnd);

                if (comparerCoefficient > mutationCoefficient)
                {
                    AllDesignPoints.Add(itemDP);
                    continue;
                }

                var newDesignPoint = itemDP.Clone();
                newDesignPoint.PopulationNumber = PopulationNumber;
                newDesignPoint.ID = PopulationId;
                PopulationId++;

                var newListBinary = newDesignPoint.X1X2.Select(itemX => itemX != 0 ? (byte) 0 : (byte) 1).ToList();

                newDesignPoint.Update(newListBinary);
                newDesignPoint.IsMutate = true;
                AllDesignPoints.Add(newDesignPoint);
                MutateDesignPoints.Add(newDesignPoint);
            }
        }
    }
}