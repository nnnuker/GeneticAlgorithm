using System.Collections.Generic;

namespace GeneticAlgorithm.Chromosome
{
    public interface IBinary
    {
        double Value { get; }
        IEnumerable<byte> BinaryValue { get; }
        int Length { get; }
        double Update(IEnumerable<byte> binaryValue);
    }
}