using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.Descendants
{
    public interface IDescendants
    {
        IEnumerable<IDesignPoint> GetDescendants(IEnumerable<IDesignPoint> designPoints); 
    }
}
