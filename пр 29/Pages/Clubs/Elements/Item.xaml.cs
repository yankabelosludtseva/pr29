using System;
using System.Windows;
using System.Windows.Controls;
using пр_29.Classes;

namespace пр_29.Pages.Clubs.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        /// <summary> Главная страница клубов </summary>
        public Main Main { get; set; }

        /// <summary> Данные клуба </summary>
        public Models.Clubs Club { get; set; }

        /// <summary>
        /// Конструктор элемента клуба
        /// </summary>
        /// <param name="club">Объект клуба с данными</param>
        /// <param name="main">Ссылка на главную страницу для навигации</param>
        public Item(Models.Clubs club, Main main)
        {
            InitializeComponent(); // ✅ Обязательно для загрузки XAML

            Club = club;
            Main = main;

            // ✅ Заполняем UI данными из объекта клуба
            LoadData();
        }

        /// <summary> Заполняет элементы интерфейса данными клуба </summary>
        private void LoadData()
        {
            // 🔹 Замените имена элементов (Name, Address, WorkTime) на ваши реальные x:Name из XAML
            if (FindName("Name") is TextBlock tbName)
                tbName.Text = Club.Name;

            if (FindName("Address") is TextBlock tbAddress)
                tbAddress.Text = Club.Address;

            if (FindName("WorkTime") is TextBlock tbWorkTime)
                tbWorkTime.Text = Club.WorkTime;
        }

        /// <summary> Обработчик кнопки "Редактировать" </summary>
        private void EditClub(object sender, RoutedEventArgs e) =>
            MainWindow.init.OpenPages(new Pages.Clubs.Add(Main, Club));

        /// <summary> Обработчик кнопки "Удалить" </summary>
        private void DeleteClub(object sender, RoutedEventArgs e)
        {
            // Подтверждение удаления
            var result = MessageBox.Show(
                $"Удалить клуб \"{Club.Name}\"?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes) return;

            // Удаляем из контекста БД
            Main.AllClub.Clubs.Remove(Club);
            Main.AllClub.SaveChanges();

            // Удаляем визуальный элемент
            if (Parent is Panel parentPanel)
                parentPanel.Children.Remove(this);
        }
    }
}