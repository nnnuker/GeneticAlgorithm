using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using GeneticAlgorithm;
using ORM;

namespace PresentationForms
{
    public partial class MainForm : Form
    {
        #region Fields

        private DesignPointsData dataAdapter;
        private DesignPointsGraph graphAdapter;
        private GAlgorithm algorithm;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Steps

        private void bToEnd_Click(object sender, EventArgs e)
        {
            for (int i = algorithm.PopulationNumber; i < Int32.Parse(tBoxExeEnd.Text); i++)
            {
                if (algorithm.CurrentDesignPoints.Count(y => y.IsAlive) == 0)
                {
                    GetBest();
                    return;
                }
                algorithm.MoveNext();
                AppData();
            }
            GetBest();
        }

        private void bOneStep_Click(object sender, EventArgs e)
        {
            algorithm.MoveNext();
            AppData();
        }

        #endregion

        #region Append data

        private void AppData()
        {
            var res1 = algorithm.ListOfSelectedPoints.Select(x => new DesignPointViewModel(x));
            dataAdapter.AddPopulation(res1, Color.Blue);
            var res2 = algorithm.ListOfFirst.Select(x => new DesignPointViewModel(x));
            dataAdapter.AddPopulation(res2, Color.BlueViolet);
            var res3 = algorithm.ListOfSecond.Select(x => new DesignPointViewModel(x));
            dataAdapter.AddPopulation(res3, Color.Brown);
            var res = algorithm.CurrentDesignPoints.Select(x => new DesignPointViewModel(x));
            if (!dataAdapter.AddPopulation(res, Color.LightGreen))
            {
                return;
            }
            graphAdapter.AddRange(res);
        }

        private void GetBest()
        {
            var best = algorithm.ListOfAllDesignPoints
                .Where(y => y.IsAlive)
                .OrderBy(x => x.FunctionValue)
                .Select(x => new DesignPointViewModel(x))
                .First();
            dataAdapter.AddBest(best);
            graphAdapter.AddBest(best);
            ResultService.SaveResult(best.Value);
        }

        #endregion

        #region Methods

        private void Initialize(int accuracy, int N, int m, int percent, int end, double minX, double maxX,
            double minY, double maxY, string formula)
        {
            algorithm = GaService.GetGa(accuracy, N, m, percent, end, minX, maxX,
            minY, maxY, formula);
        }

        private void bInitialize_Click(object sender, EventArgs e)
        {
            var addRange = 1;

            try
            {
                var leftX1 = DoubleParser(tBoxX1Left);
                var rightX1 = DoubleParser(tBoxX1Right);
                var leftX2 = DoubleParser(tBoxX2Left);
                var rightX2 = DoubleParser(tBoxX2Right);
                var accuracy = IntParser(tBoxAccuracy);
                var N = IntParser(tBoxN);
                var m = IntParser(tBoxMutation);
                var percent = IntParser(tBoxPercent);
                var end = IntParser(tBoxExeEnd);

                dataAdapter = new DesignPointsData(dataGridView);
                graphAdapter = new DesignPointsGraph(chart, (int)leftX1 - addRange, (int)rightX1 + addRange,
                    (int)leftX2 - addRange, (int)rightX2 + addRange);
                Initialize(accuracy, N, m, percent, end, leftX1, rightX1, leftX2, rightX2, tBoxFormula.Text);
                AppData();
            }
            catch (FormatException exception)
            {
                MessageBox.Show($"Please write correct data in {exception.Message}.");
            }
        }

        #region Parsers

        private double DoubleParser(TextBox textBox)
        {
            double result;
            var flag = Double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out result);

            if (!flag)
            {
                throw new FormatException(textBox.Name);
            }

            return result;
        }

        private int IntParser(TextBox textBox)
        {
            int result;
            var flag = Int32.TryParse(textBox.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);

            if (!flag)
            {
                throw new FormatException();
            }

            return result;
        }

        #endregion

        private void bChangeGA_Click(object sender, EventArgs e)
        {
            Form form = new ChangeGAForm();

            form.ShowDialog();
        }

        #endregion

    }
}
