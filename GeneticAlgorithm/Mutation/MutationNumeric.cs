using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.Mutation
{
    public class MutationNumeric : IMutation
    {
        private double mutationCoefficient;

        public MutationNumeric() : this(0)
        {

        }

        public MutationNumeric(double mutationCoefficient)
        {
            this.mutationCoefficient = mutationCoefficient;
        }

        public IEnumerable<IDesignPoint> Mutate(IEnumerable<IDesignPoint> designPoints)
        {
            throw new System.NotImplementedException();
        }
    }
}