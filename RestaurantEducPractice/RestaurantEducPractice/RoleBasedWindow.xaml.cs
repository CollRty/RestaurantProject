using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RestaurantEducPractice
{
    public partial class RoleBasedWindow : Window
    {
        private readonly string _fullName;

        public RoleBasedWindow(string fullName, string role)
        {
            InitializeComponent();
            _fullName = fullName;
            UserNameText.Text = fullName;
            UserRoleText.Text = role;
            GenerateSidebarForRole(role);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void GenerateSidebarForRole(string role)
        {
            SidebarPanel.Children.Clear();

            void AddControlButton(string content, UserControl control)
            {
                var button = new Button
                {
                    Content = content,
                    Margin = new Thickness(10),
                    Height = 40,
                    FontSize = 14,
                    Background = Brushes.Transparent,
                    Foreground = Brushes.White,
                    BorderBrush = Brushes.Gray
                };
                button.Click += (s, e) =>
                {
                    MainContentArea.Children.Clear();
                    MainContentArea.Children.Add(control);
                };
                SidebarPanel.Children.Add(button);
            }

            void AddActionButton(string content, Action action)
            {
                var button = new Button
                {
                    Content = content,
                    Margin = new Thickness(10),
                    Height = 40,
                    FontSize = 14,
                    Background = Brushes.Transparent,
                    Foreground = Brushes.White,
                    BorderBrush = Brushes.Gray
                };
                button.Click += (s, e) => action();
                SidebarPanel.Children.Add(button);
            }

            switch (role.ToLower())
            {
                case "админ":
                    AddControlButton("Управлять ролями", new Admin_RoleManagement());
                    AddControlButton("Управление меню", new Admin_MenuManagement());
                    AddControlButton("Статистика", new Admin_Statistics());
                    AddControlButton("Управление столами", new Admin_TableManagement());
                    AddControlButton("Просмотр бронирований", new Admin_ReservationsView());
                    break;
                case "официант":
                    AddControlButton("Бронирование столов", new Waiter_TableReservations(_fullName));
                    AddActionButton("Создать заказ", () => new Waiter_CreateOrderWindow(_fullName).ShowDialog());
                    break;
            }
        }
    }
}