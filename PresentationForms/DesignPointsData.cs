using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PresentationForms
{
    public class DesignPointsData
    {
        private DataGridView grid;

        public DesignPointsData(DataGridView grid)
        {
            this.grid = grid;
            this.AddColumns();
        }

        public void Add(DesignPointViewModel designPoint)
        {
            grid.Rows.Insert(0, this.GetFulldId(designPoint), designPoint.X, designPoint.Y, designPoint.IsAlive, designPoint.Binary, designPoint.Value);
            if (designPoint.IsAlive == false)
            {
                grid.Rows[0].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        public void AddPopulation(IEnumerable<DesignPointViewModel> designPoints)
        {
            foreach (var ind in designPoints.ToList().OrderBy(x => x.IsAlive).ThenByDescending(x => x.Id))
            {
                this.Add(ind);
            }

            grid.Rows.Insert(designPoints.Count());
            grid.Rows[designPoints.Count()].DefaultCellStyle.BackColor = Color.Black;
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
            var healthCol = grid.Columns.Add("Health", "Health");
            grid.Columns[healthCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[healthCol].FillWeight = 0.1f;
            var binCol = grid.Columns.Add("Binary", "Binary");
            grid.Columns[binCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[binCol].FillWeight = 0.5f;
            var valueCol = grid.Columns.Add("Value", "Value");
            grid.Columns[binCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[binCol].FillWeight = 0.5f;
        }

    }
}