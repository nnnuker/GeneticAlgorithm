using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PresentationFormsPart2
{
    public class DesignPointsData
    {
        private readonly DataGridView grid;

        public DesignPointsData(DataGridView grid)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            this.grid = grid;
            this.AddColumns();
        }

        public void Add(DesignPointViewModel designPoint)
        {
            grid.Rows.Insert(grid.Rows.Count - 1, this.GetFulldId(designPoint), designPoint.N, designPoint.n,
                designPoint.Population, designPoint.SelectStartPoints, designPoint.SearchMethod, designPoint.Search,
                designPoint.SelectOtherPoints, designPoint.Binary, designPoint.Value);
            if (designPoint.IsMutate)
            {
                grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Violet;
            }
        }

        public DesignPointViewModel AddPopulation(IEnumerable<DesignPointViewModel> designPoints, Color color)
        {
            if (!designPoints.Any())
            {
                return null;
            }

            foreach (var ind in designPoints.ToList().OrderBy(x => x.Id))
            {
                this.Add(ind);
            }

            var val = designPoints.OrderBy(x => x.Value).First();
            grid.Rows.Insert(grid.Rows.Count - 1, this.GetFulldId(val), val.N, val.n, val.Population, val.SelectStartPoints, 
                val.SearchMethod, val.Search, val.SelectOtherPoints, val.Binary, val.Value);
            grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Gold;
            

            grid.Rows.Insert(grid.Rows.Count - 1);
            grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = color;

            return val;
        }

        public void AddBest(DesignPointViewModel designPoint)
        {
            grid.Rows.Insert(grid.Rows.Count - 1);
            grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Green;

            grid.Rows.Insert(grid.Rows.Count - 1, this.GetFulldId(designPoint), designPoint.N, designPoint.n, 
                designPoint.Population, designPoint.SelectStartPoints, designPoint.SearchMethod, designPoint.Search, 
                designPoint.SelectOtherPoints, designPoint.Binary, designPoint.Value);
            grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Gold;
        }

        private string GetFulldId(DesignPointViewModel designPointViewModel)
        {
            return $"{designPointViewModel.PopulationNumber}.{designPointViewModel.Id}";
        }

        private void AddColumns()
        {
            var idCol = grid.Columns.Add("Id", "Id");
            grid.Columns[idCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[idCol].FillWeight = 0.075f;

            var NCol = grid.Columns.Add("N", "N");
            grid.Columns[NCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[NCol].FillWeight = 0.05f;

            var nCol = grid.Columns.Add("n", "n");
            grid.Columns[nCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[nCol].FillWeight = 0.05f;

            var populationCol = grid.Columns.Add("Population", "Population");
            grid.Columns[populationCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[populationCol].FillWeight = 0.1f;

            var selectStartPointsCol = grid.Columns.Add("SelectStartPoints", "SelectStartPoints");
            grid.Columns[selectStartPointsCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[selectStartPointsCol].FillWeight = 0.1f;

            var searchMethodCol = grid.Columns.Add("SearchMethod", "SearchMethod");
            grid.Columns[searchMethodCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[searchMethodCol].FillWeight = 0.1f;

            var searchCol = grid.Columns.Add("Search", "Search");
            grid.Columns[searchCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[searchCol].FillWeight = 0.1f;

            var selectOtherPointsCol = grid.Columns.Add("SelectOtherPoints", "SelectOtherPoints");
            grid.Columns[selectOtherPointsCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[selectOtherPointsCol].FillWeight = 0.1f;

            var allCol = grid.Columns.Add("All", "All");
            grid.Columns[allCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[allCol].FillWeight = 0.15f;

            var valueCol = grid.Columns.Add("Value", "Value");
            grid.Columns[valueCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[valueCol].FillWeight = 0.1f;
        }

    }
}