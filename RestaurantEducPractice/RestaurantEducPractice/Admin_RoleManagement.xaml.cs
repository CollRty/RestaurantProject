using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantEducPractice
{
    public partial class Admin_RoleManagement : UserControl
    {
        public ObservableCollection<ClientWithRoles> Clients { get; set; } = new();
        private readonly string[] roles = { "клиент", "официант", "админ" };

        public Admin_RoleManagement()
        {
            InitializeComponent();
            this.Tag = roles.ToList(); // Для ComboBox
            LoadClients();
        }

        private async void LoadClients()
        {
            try
            {
                var client = App.SupabaseClient;
                var response = await client.From<Client>().Get();
                Clients.Clear();

                foreach (var c in response.Models)
                {
                    Clients.Add(new ClientWithRoles
                    {
                        Id = c.Id,
                        FullName = c.FullName,
                        Email = c.Email,
                        Phone = c.Phone,
                        Role = c.Role,
                        Roles = roles
                    });
                }

                ClientsGrid.ItemsSource = Clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки пользователей: " + ex.Message);
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = App.SupabaseClient;

                foreach (var user in Clients)
                {
                    await client
                        .From<Client>()
                        .Where(x => x.Id == user.Id)
                        .Set(x => x.Role, user.Role)
                        .Update();

                    await HandleWaiterSync(user);
                }

                MessageBox.Show("Роли успешно обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении ролей: " + ex.Message);
            }
        }

        private async Task HandleWaiterSync(ClientWithRoles user)
        {
            var client = App.SupabaseClient;

            if (user.Role == "официант")
            {
                // Проверка, нет ли уже этого официанта
                var existing = await client.From<Waiter>()
                    .Where(x => x.Email == user.Email)
                    .Get();

                if (!existing.Models.Any())
                {
                    await client.From<Waiter>().Insert(new Waiter
                    {
                        FullName = user.FullName,
                        Email = user.Email,
                        Password = user.Password
                    });
                }
            }
            else
            {
                // Если не официант — удалить из таблицы waiters
                var existing = await client.From<Waiter>()
                    .Where(x => x.Email == user.Email)
                    .Get();

                foreach (var w in existing.Models)
                {
                    await client.From<Waiter>().Delete(w);
                }
            }
        }

        private async void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.DataContext is Client selectedClient)
            {
                string newRole = comboBox.SelectedItem?.ToString();

                if (!string.IsNullOrWhiteSpace(newRole) && newRole != selectedClient.Role)
                {
                    try
                    {
                        var client = App.SupabaseClient;

                        // Обновляем роль в clients
                        selectedClient.Role = newRole;
                        await client
                            .From<Client>()
                            .Where(x => x.Id == selectedClient.Id)
                            .Set(x => x.Role, newRole)
                            .Update();

                        // --- ДОБАВЛЯЕМ/УДАЛЯЕМ из waiters ---
                        if (newRole == "официант")
                        {
                            // Проверка, существует ли уже в таблице waiters
                            var existing = await client
                                .From<Waiter>()
                                .Where(w => w.Email == selectedClient.Email)
                                .Get();

                            if (!existing.Models.Any())
                            {
                                var waiter = new Waiter
                                {
                                    Id = Guid.NewGuid().ToString(), // генерируем новый id
                                    FullName = selectedClient.FullName,
                                    Email = selectedClient.Email,
                                    Password = selectedClient.Password // ⚠️ пароль виден в clients
                                };

                                await client.From<Waiter>().Insert(waiter);
                            }
                        }
                        else
                        {
                            // Если роль больше не официант — удалить из таблицы waiters
                            await client
                                .From<Waiter>()
                                .Where(w => w.Email == selectedClient.Email)
                                .Delete();
                        }

                        MessageBox.Show($"Роль пользователя {selectedClient.FullName} изменена на {newRole}.", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении роли: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public class ClientWithRoles : Client
        {
            public string[] Roles { get; set; }
        }
    }
}
