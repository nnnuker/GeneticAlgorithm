using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Crossover;

namespace GeneticAlgorithm.Descendants
{
    public interface IDescendants
    {
        IEnumerable<IDesignPoint> GetDescendants(ICrossover crossover, double mutationCoeff);
    }
}
