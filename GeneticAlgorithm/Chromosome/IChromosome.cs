using System.Collections.Generic;

namespace GeneticAlgorithm.Chromosome
{
    public interface IChromosome
    {
        string Name { get; set; }
        int Accuracy { get; set; }
        double Left { get; set; }
        double Right { get; set; }
        double Value { get; set; }
        bool IsCorrect { get; }
        IEnumerable<byte> Binary { get; }
        void Update(IEnumerable<byte> binary);
        IChromosome Clone();
    }
}
