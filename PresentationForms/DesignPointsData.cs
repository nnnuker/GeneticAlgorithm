using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PresentationForms
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
            grid.Rows.Insert(grid.Rows.Count - 1, this.GetFulldId(designPoint), designPoint.X, designPoint.Y, designPoint.Binary, designPoint.Value);
            if (designPoint.IsMutate && designPoint.IsAlive)
            {
                grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Violet;
            }
            if (!designPoint.IsAlive)
            {
                grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = Color.DarkSalmon;
            }
        }

        public bool AddPopulation(IEnumerable<DesignPointViewModel> designPoints)
        {
            if (designPoints.Count() == 0)
            {
                return false;
            }

            foreach (var ind in designPoints.ToList().OrderBy(x => x.Id))
            {
                this.Add(ind);
            }

            if (designPoints.Count(y => y.IsAlive) == 0)
            {
                return false;
            }

            var val = designPoints.Where(y => y.IsAlive).OrderBy(x => x.Value).First();
            grid.Rows.Insert(grid.Rows.Count - 1, this.GetFulldId(val), val.X, val.Y, 
                val.Binary, val.Value);
            grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Gold;

            grid.Rows.Insert(grid.Rows.Count - 1);
            grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = Color.LightGreen;

            return true;
        }

        public void AddBest(DesignPointViewModel designPoint)
        {
            grid.Rows.Insert(grid.Rows.Count - 1);
            grid.Rows[grid.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Green;

            grid.Rows.Insert(grid.Rows.Count - 1, this.GetFulldId(designPoint), designPoint.X, designPoint.Y,
                designPoint.Binary, designPoint.Value);
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
            grid.Columns[idCol].FillWeight = 0.2f;
            var xCol = grid.Columns.Add("X", "X");
            grid.Columns[xCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[xCol].FillWeight = 0.1f;
            var yCol = grid.Columns.Add("Y", "Y");
            grid.Columns[yCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[yCol].FillWeight = 0.1f;
            var binCol = grid.Columns.Add("Binary", "Binary");
            grid.Columns[binCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[binCol].FillWeight = 0.5f;
            var valueCol = grid.Columns.Add("Value", "Value");
            grid.Columns[valueCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[valueCol].FillWeight = 0.1f;
        }

    }
}