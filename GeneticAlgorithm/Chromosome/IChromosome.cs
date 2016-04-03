using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Chromosome
{
    public interface IChromosome
    {
        string Name { get; set; }
        double Left { get; set; }
        double Right { get; set; }
        double Value { get; set; }
        string Binary { get; }
        double Accuracy { get; set; }
        bool IsCorrect { get; }
    }
}
