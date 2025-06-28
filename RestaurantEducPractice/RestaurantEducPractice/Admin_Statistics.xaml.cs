using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

namespace RestaurantEducPractice
{
    public partial class Admin_Statistics : UserControl
    {
        public ObservableCollection<DishStat> DishStatistics { get; set; } = new();
        public ObservableCollection<CategoryStat> CategoryStatistics { get; set; } = new();

        public Admin_Statistics()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private async void LoadStatistics()
        {
            try
            {
                var client = App.SupabaseClient;

                var dishes = await client.From<Dish>().Get();
                var orderItems = await client.From<OrderItem>().Get();

                DishStatistics.Clear();
                CategoryStatistics.Clear();

                foreach (var dish in dishes.Models)
                {
                    var relatedItems = orderItems.Models
                        .Where(x => x.DishName == dish.Name)
                        .ToList();

                    var totalQuantity = relatedItems.Sum(x => x.Quantity);
                    var totalRevenue = relatedItems.Sum(x => x.PriceAtOrder);

                    DishStatistics.Add(new DishStat
                    {
                        DishName = dish.Name,
                        TotalOrdered = totalQuantity,
                        TotalRevenue = totalRevenue
                    });
                }

                var categoryGroups = dishes.Models
                    .GroupBy(x => x.CategoryName)
                    .Select(g =>
                    {
                        var dishNames = g.Select(d => d.Name);
                        var orderCount = orderItems.Models
                            .Where(o => dishNames.Contains(o.DishName))
                            .Sum(o => o.Quantity);

                        return new CategoryStat
                        {
                            Category = g.Key,
                            OrderCount = orderCount
                        };
                    });

                foreach (var stat in categoryGroups)
                    CategoryStatistics.Add(stat);

                DishStatsGrid.ItemsSource = DishStatistics;
                CategoryStatsGrid.ItemsSource = CategoryStatistics;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке статистики: " + ex.Message);
            }
        }

        public class DishStat
        {
            public string DishName { get; set; }
            public int TotalOrdered { get; set; }
            public decimal TotalRevenue { get; set; }
        }

        public class CategoryStat
        {
            public string Category { get; set; }
            public int OrderCount { get; set; }
        }
    }
}