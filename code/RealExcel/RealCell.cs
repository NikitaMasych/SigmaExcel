using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealExcel
{
    public class RealCell : DataGridViewTextBoxCell
    {
        public int rowIndex { get; }
        public int columnIndex {get; }
        public string Expression { get; set; }
        public string Evaluation { get; set; }
        public HashSet<RealCell> cellsIDependOn = new HashSet<RealCell>();
        public HashSet<RealCell> dependentOnMeCells = new HashSet<RealCell>();

        public RealCell(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }
        public bool CheckForDependenciesCycle(ref RealCell current)
        {
            foreach (var cell in cellsIDependOn)
            {
                if (cell.cellsIDependOn.Contains(current))
                {
                    return true;
                }
                if (cell.CheckForDependenciesCycle(ref current))
                {
                    return true;
                }
            }
            return false;
        }
    }
}