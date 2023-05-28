using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DentistryWpfApp.View.Controls
{
    public class EditableTable : UserControl
    {
        private Grid grid;
        private List<List<TextBox>> textBoxes;

        public int Rows { get; set; }
        public int Columns { get; set; }

        public EditableTable()
        {
            grid = new Grid();
            textBoxes = new List<List<TextBox>>();

            Content = grid;

            Loaded += EditableTable_Loaded;
        }

        private void EditableTable_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }

        public void Initialize()
        {
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            grid.Children.Clear();
            textBoxes.Clear();

            for (int row = 0; row < Rows; row++)
            {
                grid.RowDefinitions.Add(new RowDefinition());

                List<TextBox> rowTextBoxes = new List<TextBox>();

                for (int col = 0; col < Columns; col++)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition());

                    TextBox textBox = new TextBox();
                    textBox.BorderThickness = new Thickness(1);
                    textBox.Margin = new Thickness(2);
                    textBox.TextChanged += TextBox_TextChanged;
                    Grid.SetRow(textBox, row);
                    Grid.SetColumn(textBox, col);

                    rowTextBoxes.Add(textBox);
                    grid.Children.Add(textBox);
                }

                textBoxes.Add(rowTextBoxes);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int row = Grid.GetRow(textBox);
            int col = Grid.GetColumn(textBox);

            OnCellTextChanged(textBox.Text, row, col);
        }

        public event CellTextChangedEventHandler CellTextChanged;

        protected virtual void OnCellTextChanged(string newText, int row, int col)
        {
            CellTextChanged?.Invoke(this, new CellTextChangedEventArgs(newText, row, col));
        }

        public string GetCellValue(int row, int col)
        {
            if (row >= 0 && row < Rows && col >= 0 && col < Columns)
            {
                return textBoxes[row][col].Text;
            }

            return string.Empty;
        }

        public void SetCellValue(int row, int col, string value)
        {
            if (row >= 0 && row < Rows && col >= 0 && col < Columns)
            {
                textBoxes[row][col].Text = value;
            }
        }
    }

    public delegate void CellTextChangedEventHandler(object sender, CellTextChangedEventArgs e);

    public class CellTextChangedEventArgs : RoutedEventArgs
    {
        public string NewText { get; }
        public int Row { get; }
        public int Column { get; }

        public CellTextChangedEventArgs(string newText, int row, int column)
        {
            NewText = newText;
            Row = row;
            Column = column;
        }
    }
}