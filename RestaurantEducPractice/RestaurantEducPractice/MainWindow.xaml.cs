using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace RestaurantEducPractice;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        string login = LoginBox.Text.Trim();
        string password = PasswordBox.Password;

        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
            var client = App.SupabaseClient;

            var response = await client
                .From<Client>()
                .Where(x => x.Email == login && x.Password == password)
                .Get();

            var user = response.Models.FirstOrDefault();

            if (user != null)
            {
                MessageBox.Show("Вход выполнен успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                var window = new RoleBasedWindow(user.FullName, user.Role);
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный email или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка при подключении к Supabase: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        var regWindow = new RegistrationWindow();
        regWindow.Show();
        this.Close();
    }
}