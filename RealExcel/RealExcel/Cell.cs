using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealExcel
{
    public class Cell : DataGridViewTextBoxCell
    {
        private int rowIndex, columnIndex;
        public string Expression { get; set; }
        public double Evaluation { get; set; }
        public List<Cell> ConjugatedCells = new List<Cell>();

        public Cell(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }
    }
}