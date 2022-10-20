using System.Collections.Generic;
using System.Windows.Forms;

namespace SigmaExcel
{
    public class SigmaCell : DataGridViewTextBoxCell
    {
        public int Row;
        public int Column;
        public bool HasDependencyCycle;
        public string Expression;
        public string Evaluation;
        public HashSet<SigmaCell> CellsIDependOn = new HashSet<SigmaCell>();
        public HashSet<SigmaCell> DependentOnMeCells = new HashSet<SigmaCell>();

        public SigmaCell(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public SigmaCell(int row, int column, string expression) 
        {
            Row = row;
            Column = column;
            Expression = expression;
        }
        public bool CheckForDependenciesCycle(ref SigmaCell current)
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
        public SigmaCell DeepCopy()
        {
            var newCell = new SigmaCell(Row, Column, Expression);
            newCell.HasDependencyCycle = HasDependencyCycle;
            newCell.Evaluation = Evaluation;
            var iDependOn = new HashSet<SigmaCell>(CellsIDependOn);
            newCell.CellsIDependOn = iDependOn;
            var dependOnMe = new HashSet<SigmaCell>(DependentOnMeCells);
            newCell.DependentOnMeCells = dependOnMe;
            return newCell;
        }
        public bool Equals(SigmaCell another)
        {
            return (Row == another.Row &&
                    Column == another.Column &&
                    HasDependencyCycle == another.HasDependencyCycle &&
                    Expression == another.Expression &&
                    Evaluation == another.Evaluation &&
                    CellsIDependOn.Equals(another.CellsIDependOn) &&
                    DependentOnMeCells.Equals(another.DependentOnMeCells));
        }
        public bool DoIDependOn(SigmaCell current)
        {
            foreach (var cell in CellsIDependOn)
            {
                if (cell.Row == current.Row && cell.Column == current.Column)
                {
                    return true;
                }
            }
            return false;
        }
    }
}