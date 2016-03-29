using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.PairFormation
{
    public interface IPair
    {
        IDesignPoint First { get; set; }
        IDesignPoint Second { get; set; }
    }
}
