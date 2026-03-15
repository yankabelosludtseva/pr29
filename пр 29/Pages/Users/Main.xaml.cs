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
using System.Xml.Linq;
using пр_29.Classes;

namespace пр_29.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        /// <summary> Контекст пользователей
        public UserContext AllUsers = new UserContext();

        public Main()
        {
            InitializeComponent();
            // Перебираем пользователей
            foreach (Models.Users User in AllUsers.Users)
                // Добавляем на экран
                Parent.Children.Add(new Elements.Item(User, this));
        }

        /// <summary> Метод добавления пользователей
        private void AddUser(object sender, RoutedEventArgs e) =>
            // Открываем страницу добавления пользователей
            MainWindow.init.OpenPages(new Pages.Users.Add(this));
    }
}
