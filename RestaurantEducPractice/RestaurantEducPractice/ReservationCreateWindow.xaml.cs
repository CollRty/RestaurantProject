using System;
using System.Linq;
using System.Windows;

namespace RestaurantEducPractice
{
    public partial class ReservationCreateWindow : Window
    {
        public ReservationCreateWindow()
        {
            InitializeComponent();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            string fullName = FullNameBox.Text.Trim();
            string tableNumber = TableNumberBox.Text.Trim();
            string date = DatePicker.SelectedDate?.ToString("yyyy-MM-dd") ?? "";
            string time = TimeBox.Text.Trim();
            string guests = GuestsBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(tableNumber) ||
                string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(time) ||
                string.IsNullOrWhiteSpace(guests) || !int.TryParse(guests, out int guestsCount) || guestsCount > 4)
            {
                MessageBox.Show("Заполните все поля корректно (гостей: 1-4).");
                return;
            }

            try
            {
                var client = App.SupabaseClient;

                // Проверка существования стола
                var tables = await client.From<Table>().Where(t => t.TableNumber == tableNumber).Get();
                var table = tables.Models.FirstOrDefault();

                if (table == null)
                {
                    MessageBox.Show("Стол не найден.");
                    return;
                }

                if (table.Status.ToLower() == "занято")
                {
                    MessageBox.Show("Стол уже занят, выберите другой.");
                    return;
                }

                // Получаем список всех официантов
                var waiters = await client.From<Waiter>().Get();

                // Проверяем текущие бронирования
                var reservations = await client.From<Reservation>().Where(x => x.Status == "Зарезервировано").Get();
                var busyWaiters = reservations.Models.Select(r => r.WaiterName).ToList();

                // Выбираем свободного
                var availableWaiter = waiters.Models.FirstOrDefault(w => !busyWaiters.Contains(w.FullName));

                if (availableWaiter == null)
                {
                    MessageBox.Show("Нет свободных официантов для бронирования.");
                    return;
                }

                var newRes = new Reservation
                {
                    Id = Guid.NewGuid().ToString(),
                    FullName = fullName,
                    TableNumber = tableNumber,
                    ReservationDate = date,
                    ReservationTime = time,
                    GuestsCount = guestsCount,
                    Status = "Зарезервировано",
                    WaiterName = availableWaiter.FullName
                };

                await client.From<Reservation>().Insert(newRes);

                MessageBox.Show($"Бронирование создано и назначено официанту: {availableWaiter.FullName}");
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании бронирования: " + ex.Message);
            }
        }
    }
}