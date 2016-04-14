using GeneticAlgorithm.DesignPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.SelectPoints
{
    class DegreesWithIDesignPoint
    {
        public IDesignPoint DesignPoint { get; set; }
        public double Degreese { get; set; }

        public DegreesWithIDesignPoint()
        {

        }

        public DegreesWithIDesignPoint(IDesignPoint designPoint, double degreese)
        {
            this.DesignPoint = designPoint;
            this.Degreese = degreese;
        }
    }
}
