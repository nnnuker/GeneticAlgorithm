using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace PresentationFormsPart2
{
    public class DesignPointsGraph
    {
        private Chart graph;
        private Series series;
        private Dictionary<int, Color> colors;
        private DesignPointViewModel currentDesignPointViewModel;

        public static int numberId;

        public ChartArea Area { get; set; }

        static DesignPointsGraph()
        {
            numberId = 1;
        }

        public DesignPointsGraph(Chart graph, int minX, int maxX, int minY, int maxY)
        {
            this.graph = graph;
            this.graph.ChartAreas.Clear();
            this.graph.Series.Clear();
            this.graph.Legends.Clear();
            Area = this.graph.ChartAreas.Add("graph");
            Area.AxisX.Minimum = minX;
            Area.AxisX.Maximum = maxX;
            Area.AxisX.Interval = Math.Round((Math.Abs(minX) + Math.Abs(maxX))/10.0);
            Area.AxisY.Minimum = minY;
            Area.AxisY.Maximum = maxY;
            Area.AxisY.Interval = Math.Round((Math.Abs(minX) + Math.Abs(maxX)) / 10.0);
            series = this.graph.Series.Add("designPoint");
            series.ChartType = SeriesChartType.Point;
            series.MarkerSize = 7;
        }

        private Dictionary<int, Color> SetColors(DesignPointViewModel designPoint)
        {
            var randomGen = new Random((int)(DateTime.Now.Ticks));
            var names = (KnownColor[])Enum.GetValues(typeof(KnownColor));

            var usedColors = new List<Color>();
            var result = new Dictionary<int, Color> {{0, Color.White}};
            var allId = new List<int>();

            foreach (var allPoint in designPoint.AllPoints)
            {
                if (!allId.Contains(allPoint.ID))
                {
                    allId.Add(allPoint.ID);
                }
            }

            foreach (var i in allId)
            {
                Color randomColor;
                do
                {
                    var randomColorName = names[randomGen.Next(names.Length)];
                    randomColor = Color.FromKnownColor(randomColorName);
                } while (usedColors.Contains(randomColor));
                usedColors.Add(randomColor);
                result.Add(i, randomColor);
            }
            return result;

        }

        public void DrawPrevNextBestVersion()
        {
            series.Points.Clear();

            if (numberId == colors.Count)
            {
                numberId = 1;
            }
            if (numberId == 0)
            {
                numberId = colors.Count;
            }

            foreach (var allPoint in currentDesignPointViewModel.AllPoints)
            {
                if (allPoint.ID == numberId)
                {
                    var point = new DataPoint();
                    var pointId = series.Points.AddXY(allPoint.X[0].Value, allPoint.X[1].Value);
                    point = series.Points[pointId];
                    point.Label = allPoint.PopulationNumber.ToString();
                    point.MarkerStyle = MarkerStyle.Circle;
                    point.Color = colors.First(c => c.Key == allPoint.ID).Value;
                }
            }
        }

        public void DrawFirstBestVersion(DesignPointViewModel designPoint)
        {
            series.Points.Clear();
            currentDesignPointViewModel = designPoint;
            colors = SetColors(currentDesignPointViewModel);

            numberId = 1;

            foreach (var allPoint in currentDesignPointViewModel.AllPoints)
            {
                if (allPoint.ID == numberId)
                {
                    var point = new DataPoint();
                    var pointId = series.Points.AddXY(allPoint.X[0].Value, allPoint.X[1].Value);
                    point = series.Points[pointId];
                    point.Label = allPoint.PopulationNumber.ToString();
                    point.MarkerStyle = MarkerStyle.Circle;
                    point.Color = colors.First(c => c.Key == allPoint.ID).Value;
                }
            }


        }
    }
}