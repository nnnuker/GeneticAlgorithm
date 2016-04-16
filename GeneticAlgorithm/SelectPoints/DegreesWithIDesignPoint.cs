using GeneticAlgorithm.DesignPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.SelectPoints
{
    internal class DegreesWithIDesignPoint
    {
        public IDesignPoint DesignPoint { get; set; }
        public double Degrees { get; set; }

        public DegreesWithIDesignPoint()
        {
        }

        public DegreesWithIDesignPoint(IDesignPoint designPoint, double degrees)
        {
            this.DesignPoint = designPoint;
            this.Degrees = degrees;
        }
    }
}
