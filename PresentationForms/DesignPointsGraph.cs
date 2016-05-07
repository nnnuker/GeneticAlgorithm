using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace PresentationForms
{
    public class DesignPointsGraph
    {
        private Chart graph;
        private Series series;
        private readonly Color deadColor = Color.Gray;
        private readonly Color invalidColor = Color.Red;
        private readonly Color healthyColor = Color.Green;
        private MarkerStyle deadMarker = MarkerStyle.Circle;
        private MarkerStyle healthyMarker = MarkerStyle.Circle;

        public ChartArea Area { get; set; }

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
            series.MarkerSize = 10;
        }

        public void AddRange(IEnumerable<DesignPointViewModel> designPoints)
        {
            foreach (var p in series.Points)
            {
                p.MarkerStyle = deadMarker;
                p.Color = deadColor;
            }

            foreach (var item in designPoints)
            {
                var point = series.Points.FirstOrDefault(x => x.XValue == item.X && x.YValues[0] == item.Y);
                if (point == null)
                {
                    var pointId = series.Points.AddXY(item.X, item.Y);
                    point = series.Points[pointId];
                }

                if (item.IsAlive)
                {
                    point.MarkerStyle = healthyMarker;
                    point.Color = healthyColor;
                }
                else
                {
                    point.MarkerStyle = deadMarker;
                    point.Color = invalidColor;
                }
            }
        }

        public void AddBest(DesignPointViewModel designPoint)
        {
            foreach (var p in series.Points)
            {
                p.MarkerStyle = deadMarker;
                p.Color = deadColor;
            }

            var point = series.Points.FirstOrDefault(x => x.XValue == designPoint.X && x.YValues[0] == designPoint.Y);

            point.MarkerStyle = healthyMarker;
            point.Color = Color.Gold;
        }
    }
}