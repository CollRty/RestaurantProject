using System.Text.RegularExpressions;
using System.Windows;
using RestaurantEducPractice;

namespace RestaurantEducPractice;

public partial class RegistrationWindow : Window
{
    public RegistrationWindow()
    {
        InitializeComponent();
    }

    private async void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        string fullName = FullNameBox.Text.Trim();
        string email = EmailBox.Text.Trim();
        string phone = PhoneBox.Text.Trim();
        string password = PasswordBox.Password;
        string confirmPassword = ConfirmPasswordBox.Password;

        if (fullName.Split(' ').Length != 3)
        {
            MessageBox.Show("Введите полное ФИО (Фамилия Имя Отчество).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            MessageBox.Show("Некорректный email.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (!Regex.IsMatch(phone, @"^\+?\d{10,15}$"))
        {
            MessageBox.Show("Некорректный номер телефона.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (password.Length < 3)
        {
            MessageBox.Show("Пароль должен содержать минимум 3 символа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (password != confirmPassword)
        {
            MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
            var client = App.SupabaseClient;

            var existing = await client
                .From<Client>()
                .Where(x => x.Email == email)
                .Get();

            if (existing.Models.Any())
            {
                MessageBox.Show("Пользователь с таким email уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newClient = new Client
            {
                FullName = fullName,
                Email = email,
                Phone = phone,
                Password = password,
                Role = "клиент"
            };

            var result = await client.From<Client>().Insert(newClient);

            MessageBox.Show("Пользователь успешно зарегистрирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            var loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка при сохранении пользователя: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        var loginWindow = new MainWindow();
        loginWindow.Show();
        this.Close();
    }
}