using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.PairFormation
{
    public interface IPairFormation
    {
        IEnumerable<IPair> FormatPairs(IEnumerable<IDesignPoint> designPoints);
    }
}
