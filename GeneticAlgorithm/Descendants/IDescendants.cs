using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.Descendants
{
    public interface IDescendants
    {
        IEnumerable<IDesignPoint> GetAllDesignPoints { get; }
        IEnumerable<IDesignPoint> GetAfterFirst { get; }
        IEnumerable<IDesignPoint> GetAfterSecond { get; }
        IEnumerable<IDesignPoint> GetDescendants(IEnumerable<IDesignPoint> designPoints);
    }
}
