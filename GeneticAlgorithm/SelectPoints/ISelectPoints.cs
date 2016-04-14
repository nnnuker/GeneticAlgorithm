using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.SelectPoints
{
    public interface ISelectPoints
    {
        IEnumerable<IDesignPoint> SelectPoints(int n, IEnumerable<IDesignPoint> designPoints);
    }
}
