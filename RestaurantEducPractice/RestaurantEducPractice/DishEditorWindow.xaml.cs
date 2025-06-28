using System.Windows;
using System.Windows.Controls;

namespace RestaurantEducPractice
{
    public partial class DishEditorWindow : Window
    {
        public DishWithInventory EditedDish { get; private set; }

        public DishEditorWindow(DishWithInventory dish = null)
        {
            InitializeComponent();

            if (dish != null)
            {
                EditedDish = new DishWithInventory
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Price = dish.Price,
                    CategoryName = dish.CategoryName,
                    PortionsAvailable = dish.PortionsAvailable
                };

                NameBox.Text = EditedDish.Name;
                PriceBox.Text = EditedDish.Price.ToString();
                PortionsBox.Text = EditedDish.PortionsAvailable.ToString();

                foreach (ComboBoxItem item in CategoryBox.Items)
                {
                    if ((string)item.Content == dish.CategoryName)
                    {
                        CategoryBox.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                EditedDish = new DishWithInventory();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) ||
                !decimal.TryParse(PriceBox.Text, out decimal price) ||
                CategoryBox.SelectedItem is not ComboBoxItem categoryItem ||
                !int.TryParse(PortionsBox.Text, out int portions))
            {
                MessageBox.Show("Пожалуйста, корректно заполните все поля.");
                return;
            }

            EditedDish.Name = NameBox.Text.Trim();
            EditedDish.Price = price;
            EditedDish.CategoryName = categoryItem.Content.ToString();
            EditedDish.PortionsAvailable = portions;

            DialogResult = true;
            this.Close();
        }
    }
}