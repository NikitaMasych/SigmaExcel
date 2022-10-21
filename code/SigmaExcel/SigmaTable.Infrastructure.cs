using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SigmaExcel
{
    public enum TableState
    {
        New,
        Modified,
        Saved
    }
    public partial class SigmaTable
    {
        public TableState State = TableState.New;
        public string StoragePath;
        public List<List<SigmaCell>> Cells = new List<List<SigmaCell>>();

        public SigmaTable(ref DataGridView dataGridView)
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
            dataGridView.Rows.Add(1);
            dataGridView.Rows[dataGridView.Rows.Count - 1].HeaderCell.Value =
                (dataGridView.Rows.Count).ToString();

            ++rowsAmount;
            var cellsRow = new List<SigmaCell>();
            for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
            {
                var newCell = new SigmaCell(rowsAmount - 1, columnIndex);
                SetCellsIDependOn(newCell);
                cellsRow.Add(newCell);
            }
            Cells.Add(cellsRow);
            State = TableState.Modified;
        }
        public void AddColumn()
        {
            ++columnsAmount;
            dataGridView.Columns.Add(ExcelBaseRepresentor.ConvertToPseudo26Base(columnsAmount),
                    ExcelBaseRepresentor.ConvertToPseudo26Base(columnsAmount));

            for (int rowIndex = 0; rowIndex != rowsAmount; ++rowIndex)
            {
                var newCell = new SigmaCell(rowIndex, columnsAmount - 1);
                SetCellsIDependOn(newCell);
                Cells[rowIndex].Add(newCell);
            }
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
                DeleteExpiredDependenciesOnMe(currentCell);
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
                DeleteExpiredDependenciesOnMe(currentCell);
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

                Cells = new List<List<SigmaCell>>();
                for (int rowIndex = 0; rowIndex != rowsAmount; ++rowIndex)
                {
                    var line = reader.ReadLine();
                    var expressions = line.Split(delimiter);
                    var cellsRow = new List<SigmaCell>();
                    for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
                    {
                        cellsRow.Add(new SigmaCell(rowIndex, columnIndex, expressions[columnIndex]));
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
            FullCellUpdate(cell);
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
        public string GetSavedFileName()
        {
            if (string.IsNullOrEmpty(StoragePath))
            {
                return "Unsaved";
            }
            return Path.GetFileName(StoragePath);
        }
    }
}
