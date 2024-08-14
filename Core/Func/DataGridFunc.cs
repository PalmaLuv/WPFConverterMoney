using System.Windows.Controls;
using System.Windows.Data;
using WPFAppConverter.Core.ConverterNumber;

namespace WPFAppConverter.Core.Func
{
    public static class DataGridFunc
    {
        /// <summary>
        /// Function for adding columns
        /// </summary>
        /// <param name="dataGrid">dataGrid to which columns will be added</param>
        /// <param name="columns">Columns to be filled in (string Header, string BindingPath)</param>
        public static void AddDataGridColumns(DataGrid dataGrid, List<(string Header, string BindingPath)> columns)
        {
            // Create and add columns to RatesDataGrid2
            foreach (var column in columns)
                dataGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = column.Header,
                    Binding = new Binding(column.BindingPath)
                    { Converter = new DecimalFormatConverter() }
                });
        }
    }
}
