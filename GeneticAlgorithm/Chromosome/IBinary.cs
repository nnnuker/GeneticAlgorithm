using System.Collections.Generic;

namespace GeneticAlgorithm.Chromosome
{
    public interface IBinary
    {
        double Value { get; }
        IEnumerable<byte> BinaryValue { get; }
        int Length { get; }
        IBinary GetBinary();
        void SetValue(IEnumerable<byte> binaryValue);
    }
}