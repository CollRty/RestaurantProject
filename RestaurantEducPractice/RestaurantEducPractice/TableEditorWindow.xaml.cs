using System.Windows;
using System.Windows.Controls;

namespace RestaurantEducPractice
{
    public partial class TableEditorWindow : Window
    {
        public Table EditedTable { get; private set; }

        public TableEditorWindow(Table table = null)
        {
            InitializeComponent();
            if (table != null)
            {
                EditedTable = new Table
                {
                    Id = table.Id,
                    TableNumber = table.TableNumber,
                    Seats = table.Seats,
                    Status = table.Status
                };

                TableNumberBox.Text = table.TableNumber;
                SeatsBox.Text = table.Seats.ToString();
                StatusBox.SelectedItem = new ComboBoxItem { Content = table.Status };
            }
            else
            {
                EditedTable = new Table();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TableNumberBox.Text) ||
                !int.TryParse(SeatsBox.Text, out var seats) ||
                StatusBox.SelectedItem is not ComboBoxItem statusItem)
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.");
                return;
            }

            EditedTable.TableNumber = TableNumberBox.Text.Trim();
            EditedTable.Seats = seats;
            EditedTable.Status = statusItem.Content.ToString();

            DialogResult = true;
            this.Close();
        }
    }
}