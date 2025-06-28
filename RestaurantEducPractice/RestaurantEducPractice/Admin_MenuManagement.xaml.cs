using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantEducPractice
{
    public partial class Admin_MenuManagement : UserControl
    {
        public ObservableCollection<DishWithInventory> Dishes { get; set; } = new();

        public Admin_MenuManagement()
        {
            InitializeComponent();
            LoadDishes();
        }

        private async void LoadDishes()
        {
            try
            {
                var client = App.SupabaseClient;

                var dishResponse = await client.From<Dish>().Get();
                var inventoryResponse = await client.From<InventoryItem>().Get();

                Dishes.Clear();

                foreach (var dish in dishResponse.Models)
                {
                    var inventory = inventoryResponse.Models.FirstOrDefault(i => i.DishName == dish.Name);
                    Dishes.Add(new DishWithInventory
                    {
                        Id = dish.Id,
                        Name = dish.Name,
                        Price = dish.Price,
                        CategoryName = dish.CategoryName,
                        PortionsAvailable = inventory?.PortionsAvailable ?? 0
                    });
                }

                DishesGrid.ItemsSource = Dishes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки блюд: " + ex.Message);
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new DishEditorWindow();
            if (window.ShowDialog() == true)
            {
                try
                {
                    var dish = window.EditedDish;
                    dish.Id = Guid.NewGuid().ToString();

                    var newDish = new Dish
                    {
                        Id = dish.Id,
                        Name = dish.Name,
                        Price = dish.Price,
                        CategoryName = dish.CategoryName
                    };

                    await App.SupabaseClient.From<Dish>().Insert(newDish);

                    var inventory = new InventoryItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        DishName = dish.Name,
                        PortionsAvailable = dish.PortionsAvailable
                    };

                    await App.SupabaseClient.From<InventoryItem>().Insert(inventory);

                    var stat = new Statistics
                    {
                        Id = Guid.NewGuid().ToString(),
                        DishName = dish.Name,
                        CategoryName = dish.CategoryName,
                        OrderedCount = 0
                    };

                    await App.SupabaseClient.From<Statistics>().Insert(stat);

                    LoadDishes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении блюда: " + ex.Message);
                }
            }
        }

        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (DishesGrid.SelectedItem is DishWithInventory selected)
            {
                var window = new DishEditorWindow(selected);
                if (window.ShowDialog() == true)
                {
                    try
                    {
                        var updated = window.EditedDish;

                        await App.SupabaseClient
                            .From<Dish>()
                            .Where(x => x.Id == updated.Id)
                            .Set(x => x.Name, updated.Name)
                            .Set(x => x.Price, updated.Price)
                            .Set(x => x.CategoryName, updated.CategoryName)
                            .Update();

                        var inventory = await App.SupabaseClient
                            .From<InventoryItem>()
                            .Where(x => x.DishName == selected.Name)
                            .Get();

                        var inventoryItem = inventory.Models.FirstOrDefault();
                        if (inventoryItem != null)
                        {
                            await App.SupabaseClient
                                .From<InventoryItem>()
                                .Where(x => x.Id == inventoryItem.Id)
                                .Set(x => x.PortionsAvailable, updated.PortionsAvailable)
                                .Update();
                        }

                        var stat = await App.SupabaseClient
                            .From<Statistics>()
                            .Where(x => x.DishName == selected.Name)
                            .Get();

                        var statItem = stat.Models.FirstOrDefault();
                        if (statItem != null)
                        {
                            await App.SupabaseClient
                                .From<Statistics>()
                                .Where(x => x.Id == statItem.Id)
                                .Set(x => x.DishName, updated.Name)
                                .Set(x => x.CategoryName, updated.CategoryName)
                                .Update();
                        }

                        LoadDishes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при редактировании: " + ex.Message);
                    }
                }
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DishesGrid.SelectedItem is DishWithInventory selected)
            {
                var result = MessageBox.Show("Удалить блюдо?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var client = App.SupabaseClient;

                        await client.From<Dish>()
                            .Where(x => x.Id == selected.Id)
                            .Delete();

                        await client.From<InventoryItem>()
                            .Where(x => x.DishName == selected.Name)
                            .Delete();

                        await client.From<Statistics>()
                            .Where(x => x.DishName == selected.Name)
                            .Delete();

                        LoadDishes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении блюда: " + ex.Message);
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadDishes();
        }
    }

    public class DishWithInventory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int PortionsAvailable { get; set; }
    }
}