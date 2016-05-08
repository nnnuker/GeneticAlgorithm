using System;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.PairFormation
{
    public interface IPair : IEquatable<IPair>
    {
        IDesignPoint First { get; set; }
        IDesignPoint Second { get; set; }
    }
}
