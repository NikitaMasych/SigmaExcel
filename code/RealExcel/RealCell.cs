using System.Collections.Generic;
using System.Windows.Forms;

namespace RealExcel
{
    public class RealCell : DataGridViewTextBoxCell
    {
        public int Row;
        public int Column;
        public bool HasDependencyCycle;
        public string Expression;
        public string Evaluation;
        public HashSet<RealCell> CellsIDependOn = new HashSet<RealCell>();
        public HashSet<RealCell> DependentOnMeCells = new HashSet<RealCell>();

        public RealCell(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public RealCell(int row, int column, string expression) 
        {
            Row = row;
            Column = column;
            Expression = expression;
        }
        public bool CheckForDependenciesCycle(ref RealCell current)
        {
            foreach (var cell in CellsIDependOn)
            {
                if (cell.CellsIDependOn.Contains(current))
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