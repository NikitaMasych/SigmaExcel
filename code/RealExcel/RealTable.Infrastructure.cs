using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RealExcel
{
    public enum TableState
    {
        New,
        Modified,
        Saved
    }
    public partial class RealTable
    {
        public TableState State = TableState.New;
        public string StoragePath;
        public List<List<RealCell>> Cells = new List<List<RealCell>>();

        public RealTable(ref DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            Reset();
            State = TableState.New;
        }
        public void Reset()
        {
            columnsAmount = defaultColumnsAmount;
            rowsAmount = defaultRowsAmount;
            InitializeColumns();
            InitializeRows();
            InitializeCells();
            State = TableState.Modified;
        }
        public void AddRow()
        {
            ++rowsAmount;
            var cellsRow = new List<RealCell>();
            for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
            {
                cellsRow.Add(new RealCell(rowsAmount - 1, columnIndex));
            }
            Cells.Add(cellsRow);
            dataGridView.Rows.Add(1);
            dataGridView.Rows[dataGridView.Rows.Count - 1].HeaderCell.Value =
                (dataGridView.Rows.Count).ToString();
            UpdateAllCells();
            State = TableState.Modified;
        }
        public void AddColumn()
        {
            ++columnsAmount;
            dataGridView.Columns.Add(ExcelBaseRepresentor.ConvertToPseudo26Base(columnsAmount),
                    ExcelBaseRepresentor.ConvertToPseudo26Base(columnsAmount));

            for (int rowIndex = 0; rowIndex != rowsAmount; ++rowIndex)
            {
                Cells[rowIndex].Add(new RealCell(rowIndex, columnsAmount - 1));
            }
            UpdateAllCells();
            State = TableState.Modified;
        }
        public void DeleteRow()
        {
            if (rowsAmount == 1) return;
            foreach (var cell in Cells[rowsAmount - 1])
            {
                cell.Evaluation = "valueToCauseParsingError";
                UpdateDependentOnMeCells(cell.Row, cell.Column);
                var currentCell = cell;
                DeleteExpiredDependenciesOnMe(ref currentCell);
            }
            Cells.RemoveAt(rowsAmount - 1);
            dataGridView.Rows.RemoveAt(rowsAmount - 1);
            --rowsAmount;
            State = TableState.Modified;
        }
        public void DeleteColumn()
        {
            if (columnsAmount == 1) return;
            for (int i = 0; i != rowsAmount; ++i)
            {
                Cells[i][columnsAmount - 1].Evaluation = "valueToCauseParsingError";
                UpdateDependentOnMeCells(i, columnsAmount - 1);
                var currentCell = Cells[i][columnsAmount - 1];
                DeleteExpiredDependenciesOnMe(ref currentCell);
                Cells[i].RemoveAt(columnsAmount - 1);
            }
            dataGridView.Columns.RemoveAt(columnsAmount - 1);
            --columnsAmount;
            State = TableState.Modified;
        }
        public void SaveToCSV(string filePath)
        {
            StoragePath = filePath;
            var delimiter = Environment.GetEnvironmentVariable("DEFAULT_SEPARATOR");
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{rowsAmount.ToString()}{delimiter}{columnsAmount.ToString()}");
            foreach (var cellRow in Cells)
            {
                StringBuilder line = new StringBuilder();
                foreach (var cell in cellRow)
                {
                    line.Append($"{cell.Expression}{delimiter}");
                }
                output.AppendLine(line.ToString());
            }
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.WriteAllText(filePath, output.ToString());
            State = TableState.Saved;
        }
        public void OpenFromCSV(string filePath)
        {
            StoragePath = filePath;
            char delimiter = Environment.GetEnvironmentVariable("DEFAULT_SEPARATOR").
                ToCharArray()[0];
            using (var reader = new StreamReader(filePath))
            {
                var size = reader.ReadLine().Split(delimiter);
                rowsAmount = int.Parse(size[0]);
                columnsAmount = int.Parse(size[1]);
                InitializeColumns();
                InitializeRows();

                Cells = new List<List<RealCell>>();
                for (int rowIndex = 0; rowIndex != rowsAmount; ++rowIndex)
                {
                    var line = reader.ReadLine();
                    var expressions = line.Split(delimiter);
                    var cellsRow = new List<RealCell>();
                    for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
                    {
                        cellsRow.Add(new RealCell(rowIndex, columnIndex, expressions[columnIndex]));
                    }
                    Cells.Add(cellsRow);
                }
            }
            UpdateAllCells();
            State = TableState.Saved;
        }
        public void UpdateDependentOnMeCells(int rowIndex, int columnIndex)
        {
            var cell = Cells[rowIndex][columnIndex];
            if (cell.HasDependencyCycle)
            {
                UpdateCellsInDependencyCycle(rowIndex, columnIndex);
                return;
            }
            foreach (var dependentCell in cell.DependentOnMeCells.ToList())
            {
                UpdateCell(dependentCell.Row, dependentCell.Column);
                dataGridView.Rows[dependentCell.Row].Cells[dependentCell.Column].Value
                    = dependentCell.Evaluation;
                UpdateDependentOnMeCells(dependentCell.Row, dependentCell.Column);
            }
        }
        public void UpdateCell(int rowIndex, int columnIndex)
        {
            var cell = Cells[rowIndex][columnIndex];
            var cellBefore = cell.DeepCopy();
            FullCellUpdate(ref cell);
            if (!cellBefore.Equals(Cells[rowIndex][columnIndex]))
            {
                State = TableState.Modified;
            }
        }
        public bool IsRowEmpty(int rowIndex)
        {
            foreach (var cell in Cells[rowIndex])
            {
                if (cell.Expression != null && cell.Expression != "")
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsColumnEmpty(int columnIndex)
        {
            foreach (var cellRow in Cells)
            {
                if (cellRow[columnIndex].Expression != null && 
                    cellRow[columnIndex].Expression != "")
                {
                    return false;
                }
            }
            return true;
        }
    }
}
