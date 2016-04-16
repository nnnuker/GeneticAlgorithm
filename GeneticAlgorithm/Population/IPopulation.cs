using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.FactoryPoint;

namespace GeneticAlgorithm.Population
{
    public interface IPopulation
    {
        IEnumerable<IDesignPoint> GetPopulation();
    }
}
