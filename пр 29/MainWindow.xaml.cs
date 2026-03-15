using System.Windows;
using System.Windows.Controls;

namespace пр_29
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary> Ссылка на окно MainWindow
        public static MainWindow init;

        public MainWindow()
        {
            InitializeComponent();
            // Запоминаем ссылку
            init = this;
            // Открываем страницу клубов
            OpenPages(new Pages.Clubs.Main());
        }

        /// <summary> Метод открытия страниц
        public void OpenPages(Page Page)
        {
            // Обращаемся к фрейму и открываем страницу
            frame.Navigate(Page);
        }

        /// <summary> Клубы
        private void Clubs(object sender, RoutedEventArgs e) =>
            OpenPages(new Pages.Clubs.Main());

        /// <summary> Пользователи
        private void Users(object sender, RoutedEventArgs e) =>
            OpenPages(new Pages.Users.Main());
    }
}