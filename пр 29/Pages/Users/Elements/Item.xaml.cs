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
using пр_29.Classes;

namespace пр_29.Pages.Users.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        /// <summary> Контекст клубов
        public ClubsContext AllClub = new ClubsContext();
        /// <summary> Страница Main
        Main Main;
        /// <summary> Данные о пользователе
        Models.Users User;

        public Item(Models.Users User, Main Main)
        {
            InitializeComponent();
            // указываем фамилию в поле
            this.FIO.Text = User.FIO;
            // указываем дату аренды
            this.RentStart.Text = User.RentStart.ToString("yyyy-MM-dd");
            // указываем время аренды
            this.RentTime.Text = User.RentStart.ToString("HH:mm");
            // указываем продолжительность аренды
            this.Duration.Text = User.Duration.ToString();
            // Получаем клуб по ID, и указываем его наименование
            this.Club.Text = AllClub.Clubs.Where(x => x.Id == User.IdClub).First().Name;
            // Запоминаем страницу Main
            this.Main = Main;
            // Запоминаем пользователя
            this.User = User;
        }

        /// <summary> Метод изменения
        private void EditUser(object sender, System.Windows.RoutedEventArgs e) =>
            // Открываем страницу добавления передавая данные пользователя
            MainWindow.init.OpenPages(new Pages.Users.Add(this.Main, this.User));

        /// <summary> Метод удаления
        private void DeleteUser(object sender, System.Windows.RoutedEventArgs e)
        {
            // Удаляем пользователя из контекста
            Main.AllUsers.Users.Remove(User);
            // Сохраняем изменения
            Main.AllUsers.SaveChanges();
            // Удаляем элемент со страницы Main
            Main.Parent.Children.Remove(this);
        }
    }
}
