using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PresentationFormsPart2
{
    public class ResultsData
    {
        private readonly DataGridView grid;

        public ResultsData(DataGridView grid)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            this.grid = grid;
            this.AddColumns();
        }

        public void Add(ParseDesignPointViewModel designPoint)
        {
            grid.Rows.Insert(grid.Rows.Count - 1, designPoint.N, designPoint.n,
                designPoint.Population, designPoint.SelectStartPoints, designPoint.SearchMethod, designPoint.Search,
                designPoint.SelectOtherPoints); 
        }

        //public void AddBest(DesignPointViewModel designPoint)
        //{
        //    grid.Rows.Insert(grid.Rows.Count - 1);
        //    grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Green;

        //    grid.Rows.Insert(grid.Rows.Count - 1, this.GetFulldId(designPoint), designPoint.N, designPoint.n,
        //        designPoint.Population, designPoint.SelectStartPoints, designPoint.SearchMethod, designPoint.Search,
        //        designPoint.SelectOtherPoints, designPoint.Binary, designPoint.Value);
        //    grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Gold;
        //}


        private void AddColumns()
        {
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

        }
    }
}