using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantEducPractice
{
    public partial class Admin_TableManagement : UserControl
    {
        public ObservableCollection<Table> Tables { get; set; } = new();

        public Admin_TableManagement()
        {
            InitializeComponent();
            LoadTables();
        }

        private async void LoadTables()
        {
            try
            {
                var client = App.SupabaseClient;
                var response = await client.From<Table>().Get();
                Tables.Clear();
                foreach (var table in response.Models)
                    Tables.Add(table);
                TablesGrid.ItemsSource = Tables;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке столов: " + ex.Message);
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new TableEditorWindow();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var newTable = dialog.EditedTable;
                    newTable.Id = Guid.NewGuid().ToString();
                    await App.SupabaseClient.From<Table>().Insert(newTable);
                    LoadTables();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении стола: " + ex.Message);
                }
            }
        }

        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (TablesGrid.SelectedItem is Table selected)
            {
                var dialog = new TableEditorWindow(selected);
                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        var updated = dialog.EditedTable;
                        await App.SupabaseClient
                            .From<Table>()
                            .Where(t => t.Id == updated.Id)
                            .Set(t => t.TableNumber, updated.TableNumber)
                            .Set(t => t.Seats, updated.Seats)
                            .Set(t => t.Status, updated.Status)
                            .Update();
                        LoadTables();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении: " + ex.Message);
                    }
                }
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TablesGrid.SelectedItem is Table selected)
            {
                if (MessageBox.Show($"Удалить стол {selected.TableNumber}?", "Подтвердите", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        await App.SupabaseClient.From<Table>().Where(t => t.Id == selected.Id).Delete();
                        LoadTables();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении: " + ex.Message);
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e) => LoadTables();
    }
}