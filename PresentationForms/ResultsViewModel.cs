using ORM;

namespace PresentationForms
{
    public class ResultsViewModel
    {
        private readonly Result result;
        public int Id => result.Id;
        public int Crossover => result.CrossoverId;
        public int Population => result.PopulationId;
        public int PairFormation => result.PairFormationId;
        public int SelectPoints => result.SelectPointsId;
        public int Descendants => result.DescendantsId;
        public double FunctionValue => result.FunctionValue;
        public ResultsViewModel(Result result)
        {
            this.result = result;
        }
    }
}