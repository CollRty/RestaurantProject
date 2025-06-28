using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantEducPractice
{
    public partial class Waiter_TableReservations : UserControl
    {
        public ObservableCollection<Reservation> Reservations { get; set; } = new();

        private readonly string _waiterFullName;

        public Waiter_TableReservations(string waiterFullName)
        {
            InitializeComponent();
            _waiterFullName = waiterFullName;
            LoadReservations();
        }

        private async void LoadReservations()
        {
            try
            {
                var client = App.SupabaseClient;

                var result = await client
                    .From<Reservation>()
                    .Where(x => x.WaiterName == _waiterFullName && x.Status != "Завершен")
                    .Get();

                Reservations.Clear();

                foreach (var res in result.Models)
                    Reservations.Add(res);

                ReservationsGrid.ItemsSource = Reservations;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке бронирований: " + ex.Message);
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e) => LoadReservations();

        private async void Complete_Click(object sender, RoutedEventArgs e)
        {
            if (ReservationsGrid.SelectedItem is Reservation selected)
            {
                try
                {
                    await App.SupabaseClient
                        .From<Reservation>()
                        .Where(x => x.Id == selected.Id)
                        .Delete();

                    LoadReservations();
                    MessageBox.Show("Бронирование завершено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при завершении бронирования: " + ex.Message);
                }
            }
        }
    }
}