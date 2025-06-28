using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantEducPractice
{
    public partial class Waiter_CreateOrderWindow : Window
    {
        private readonly string waiterName;
        private List<Dish> allDishes;
        private List<Reservation> reservations;
        private List<(Dish Dish, int Quantity)> orderItems = new();

        public Waiter_CreateOrderWindow(string waiterName)
        {
            InitializeComponent();
            this.waiterName = waiterName;
            LoadData();
        }

        private async void LoadData()
        {
            var client = App.SupabaseClient;

            var resResult = await client
                .From<Reservation>()
                .Where(r => r.Status == "Зарезервировано" && r.WaiterName == waiterName)
                .Get();

            reservations = resResult.Models;
            ReservationBox.ItemsSource = reservations;
            ReservationBox.DisplayMemberPath = "FullName";

            var dishResult = await client.From<Dish>().Get();
            allDishes = dishResult.Models;

            var categories = allDishes.Select(d => d.CategoryName).Distinct().ToList();
            CategoryBox.ItemsSource = categories;
        }

        private void CategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = CategoryBox.SelectedItem?.ToString();
            if (selectedCategory != null)
            {
                var dishes = allDishes.Where(d => d.CategoryName == selectedCategory).ToList();
                DishBox.ItemsSource = dishes;
                DishBox.DisplayMemberPath = "Name";
            }
        }

        private async void AddDish_Click(object sender, RoutedEventArgs e)
        {
            if (DishBox.SelectedItem is not Dish dish ||
                !int.TryParse(QuantityBox.Text.Trim(), out int quantity) ||
                quantity <= 0)
            {
                MessageBox.Show("Выберите блюдо и введите корректное количество.");
                return;
            }

            var inventoryResult = await App.SupabaseClient
                .From<InventoryItem>()
                .Where(x => x.DishName == dish.Name)
                .Get();

            var inventory = inventoryResult.Models.FirstOrDefault();
            int available = inventory?.PortionsAvailable ?? 0;

            if (quantity > available)
            {
                MessageBox.Show($"Недостаточно порций (в наличии: {available})");
                return;
            }

            orderItems.Add((dish, quantity));
            OrderPreviewBox.Items.Add($"{dish.Name} x{quantity} = {dish.Price * quantity}₽");
        }

        private async void SaveOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ReservationBox.SelectedItem is not Reservation reservation || orderItems.Count == 0)
                {
                    MessageBox.Show("Выберите бронь и добавьте блюда.");
                    return;
                }

                var order = new Order
                {
                    Id = Guid.NewGuid().ToString(),
                    ClientName = reservation.FullName,
                    WaiterName = waiterName,
                    TableNumber = reservation.TableNumber,
                    CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                    Status = "Создан",
                    ReservationId = reservation.Id
                };

                await App.SupabaseClient.From<Order>().Insert(order);

                foreach (var (dish, qty) in orderItems)
                {
                    var item = new OrderItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        DishName = dish.Name,
                        Quantity = qty,
                        PriceAtOrder = dish.Price * qty,
                        OrderId = order.Id
                    };

                    await App.SupabaseClient.From<OrderItem>().Insert(item);

                    // ⬇️ Уменьшаем количество порций
                    var inventoryResponse = await App.SupabaseClient
                        .From<InventoryItem>()
                        .Where(x => x.DishName == dish.Name)
                        .Get();

                    var currentInventory = inventoryResponse.Models.FirstOrDefault();
                    if (currentInventory != null)
                    {
                        currentInventory.PortionsAvailable -= qty;
                        await App.SupabaseClient
                            .From<InventoryItem>()
                            .Where(x => x.Id == currentInventory.Id)
                            .Set(x => x.PortionsAvailable, currentInventory.PortionsAvailable)
                            .Update();
                    }

                    // ⬇️ Обновляем статистику
                    var statResult = await App.SupabaseClient
    .From<Statistics>()
    .Where(x => x.DishName == dish.Name)
    .Get();

                    var stat = statResult.Models.FirstOrDefault();
                    if (stat != null)
                    {
                        stat.OrderedCount += qty;

                        await App.SupabaseClient
                            .From<Statistics>()
                            .Where(x => x.Id == stat.Id)
                            .Set(x => x.OrderedCount, stat.OrderedCount)
                            .Update();
                    }
                    else
                    {
                        var newStat = new Statistics
                        {
                            Id = Guid.NewGuid().ToString(),
                            DishName = dish.Name,
                            CategoryName = dish.CategoryName,
                            OrderedCount = qty
                        };

                        await App.SupabaseClient.From<Statistics>().Insert(newStat);
                    }
                }

                MessageBox.Show("Заказ успешно создан.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении заказа: " + ex.Message);
            }
        }
    }
}