using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DentistryWpfApp.View.Controls
{
    public class EditableTable : UserControl
    {
        private Grid grid;
        private List<List<UIElement>> elements;

        public int Rows { get; set; }
        public int Columns { get; set; }

        public EditableTable()
        {
            grid = new Grid();
            elements = new List<List<UIElement>>();

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
            elements.Clear();

            for (int row = 0; row < Rows; row++)
            {
                grid.RowDefinitions.Add(new RowDefinition());

                List<UIElement> rowElements = new List<UIElement>();

                for (int col = 0; col < Columns; col++)
                {
                    if (row == Rows / 2)
                    {
                        TextBlock textBlock = new TextBlock();
                        int value = col + 1;
                        if (value > 8)
                            value = 16 - value;
                        textBlock.Text = value.ToString();
                        textBlock.TextAlignment = TextAlignment.Center;
                        textBlock.VerticalAlignment = VerticalAlignment.Center;
                        textBlock.FontSize = 14;
                        textBlock.FontWeight = FontWeights.Bold;

                        rowElements.Add(textBlock);
                        grid.Children.Add(textBlock);
                        Grid.SetRow(textBlock, row);
                        Grid.SetColumn(textBlock, col);
                    }
                    else
                    {
                        TextBox textBox = new TextBox();
                        textBox.BorderThickness = new Thickness(1);
                        textBox.Margin = new Thickness(2);
                        textBox.TextChanged += TextBox_TextChanged;
                        textBox.TextAlignment = TextAlignment.Center;

                        rowElements.Add(textBox);
                        grid.Children.Add(textBox);
                        Grid.SetRow(textBox, row);
                        Grid.SetColumn(textBox, col);
                    }
                }

                elements.Add(rowElements);
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
            if (row >= 0 && row < Rows && col >= 0 && col < Columns && elements[row][col] is TextBox textBox)
            {
                return textBox.Text;
            }

            return string.Empty;
        }

        public void SetCellValue(int row, int col, string value)
        {
            if (row >= 0 && row < Rows && col >= 0 && col < Columns && elements[row][col] is TextBox textBox)
            {
                textBox.Text = value;
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
