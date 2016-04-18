using System.Linq;
using GeneticAlgorithm.DesignPoints;

namespace PresentationForms
{
    public class DesignPointViewModel
    {
        private readonly IDesignPoint designPoint;

        public int Id => designPoint.ID;

        public int PopulationNumber => designPoint.PopulationNumber;

        public double X { get { return designPoint.X.ToList().First(x => x.Name == "X").Value; } }

        public double Y { get { return designPoint.X.ToList().First(x => x.Name == "Y").Value; } }

        public string Binary => designPoint.X1X2.ToString();

        public bool IsAlive => designPoint.IsAlive;

        public DesignPointViewModel(IDesignPoint designPoint)
        {
            this.designPoint = designPoint;
        }
    }
}