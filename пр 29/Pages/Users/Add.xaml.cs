using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using пр_29.Classes;

namespace пр_29.Pages.Users
{
    public partial class Add : Page
    {
        public ClubsContext AllClub = new ClubsContext();
        public Models.Users User;
        public Main Main;

        public Add(Main Main, Models.Users User = null)
        {
            InitializeComponent();
            this.Main = Main;

            // Добавляем элемент "Выберите ..." в начало списка
            Clubs.Items.Add("Выберите ...");

            // Заполняем список клубов
            foreach (Models.Clubs club in AllClub.Clubs)
            {
                Clubs.Items.Add(club.Name);
            }

            // Если редактирование существующего пользователя
            if (User != null)
            {
                this.User = User;
                this.FIO.Text = User.FIO;
                this.RentStart.SelectedDate = User.RentStart;
                this.RentTime.Text = User.RentStart.ToString("HH:mm");
                this.Duration.Text = User.Duration.ToString();

                // Находим и выбираем клуб
                var targetClub = AllClub.Clubs.FirstOrDefault(x => x.Id == User.IdClub);
                if (targetClub != null)
                {
                    Clubs.SelectedItem = targetClub.Name;
                }

                BtAdd.Content = "Изменить";
            }
            else
            {
                // Новый пользователь - выбираем "Выберите ..." по умолчанию
                Clubs.SelectedIndex = 0;
                RentStart.SelectedDate = DateTime.Today;
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            // Проверка на выбор клуба
            if (Clubs.SelectedIndex <= 0 || Clubs.SelectedItem == null)
            {
                MessageBox.Show("Выберите клуб!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка даты
            if (!RentStart.SelectedDate.HasValue)
            {
                MessageBox.Show("Выберите дату аренды!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Парсинг времени
            if (!TimeSpan.TryParse(RentTime.Text, out TimeSpan rentTime))
            {
                MessageBox.Show("Неверный формат времени! Используйте ЧЧ:ММ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Парсинг продолжительности
            if (!int.TryParse(Duration.Text, out int duration) || duration <= 0)
            {
                MessageBox.Show("Продолжительность должна быть положительным числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Создаём полную дату и время аренды
            DateTime DTRentStart = RentStart.SelectedDate.Value.Date + rentTime;

            // Находим выбранный клуб
            var selectedClub = AllClub.Clubs.FirstOrDefault(x => x.Name == Clubs.SelectedItem.ToString());
            if (selectedClub == null)
            {
                MessageBox.Show("Клуб не найден!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (this.User == null)
            {
                // Добавление нового пользователя
                User = new Models.Users
                {
                    FIO = this.FIO.Text.Trim(),
                    RentStart = DTRentStart,
                    Duration = duration,
                    IdClub = selectedClub.Id
                };
                this.Main.AllUsers.Users.Add(this.User);
            }
            else
            {
                // Редактирование существующего
                User.FIO = this.FIO.Text.Trim();
                User.RentStart = DTRentStart;
                User.Duration = duration;
                User.IdClub = selectedClub.Id;
            }

            // Сохраняем изменения
            this.Main.AllUsers.SaveChanges();

            // Возвращаемся на страницу пользователей
            MainWindow.init.OpenPages(new Pages.Users.Main());
        }

        // Валидация: только цифры для поля продолжительности
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}