using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.FuncCalculator;

namespace GeneticAlgorithm.DesignPoints
{
    public interface IDesignPoint
    {
        int ID { get; set; }
        int PopulationNumber { get; set; }
        List<IChromosome> X { get; set; }
        IEnumerable<byte> X1X2 { get; set; }
        double FunctionValue { get; set; }
        bool IsAlive { get; }
        bool IsMutate { get; set; }
        IDesignPoint Clone();
        void Update(IEnumerable<byte> s);
        IFuncCalculator FuncCalculator { get; set; }
    }
}
