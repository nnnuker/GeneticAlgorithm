using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;

namespace GeneticAlgorithm.DesignPoints
{
    public interface IDesignPoint
    {
        int ID { get; set; }
        int PopulationNumber { get; set; }
        List<IChromosome> X { get; set; }
        string X1X2 { get; set; }
        double FunctionValue { get; set; }
        bool IsAlive { get; }
        IDesignPoint Copy();
        void Update(string s);
        string FuncExpression { get; set; }

    }
}
