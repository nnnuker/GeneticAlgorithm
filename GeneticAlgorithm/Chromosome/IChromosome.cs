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
        int Accuracy { get; set; }
        double Left { get; set; }
        double Right { get; set; }
        double Value { get; set; }
        IBinary Binary { get; }
        bool IsCorrect { get; }
        IChromosome Clone();
    }
}
