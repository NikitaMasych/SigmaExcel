﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealExcel
{
    public class RealCell : DataGridViewTextBoxCell
    {
        private int rowIndex, columnIndex;
        public string Expression { get; set; }
        public string Evaluation { get; set; }
        public HashSet<RealCell> ConjugatedCells = new HashSet<RealCell>();

        public RealCell(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }
        public bool CheckForDependenciesCycle()
        {
            foreach(var cell in ConjugatedCells)
            {
                if (cell.ConjugatedCells.Contains(this))
                {
                    return true;
                }
                if (cell.CheckForDependenciesCycle())
                {
                    return true;
                }
            }
            return false;
        }
    }
}