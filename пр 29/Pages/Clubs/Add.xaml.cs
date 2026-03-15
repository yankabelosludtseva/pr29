using System.Windows.Controls;

namespace пр_29.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        /// <summary> Главная страница клубов
        private Main Main;
        /// <summary> Данные клуба
        private Models.Clubs Club;

        public Add(Main main, Models.Clubs club = null)
        {
            InitializeComponent();
            // Запоминаем в переменную
            this.Main = main;

            // Если пришёл клуб, отображаем данные
            if (club != null)
            {
                // Запоминаем клуб в переменную
                this.Club = club;
                // Указываем наименование
                this.Name.Text = club.Name;
                // Указываем адрес
                this.Address.Text = club.Address;
                // Указываем время работы
                this.WorkTime.Text = club.WorkTime;
                // Изменяем текст кнопки
                BthAdd.Content = "Изменить";
            }
        }

        /// <summary> Метод добавления или изменения
        private void AddClub(object sender, System.Windows.RoutedEventArgs e)
        {
            // Если клуб пустой (добавление)
            if (this.Club == null)
            {
                // Создаём новый объект
                Club = new Models.Clubs();
                // Задаём данные
                Club.Name = this.Name.Text;
                Club.Address = this.Address.Text;
                Club.WorkTime = this.WorkTime.Text;
                // Добавляем объект в контекст
                this.Main.AllClub.Clubs.Add(this.Club);
            }
            else
            {
                // Если изменение
                // Изменяем данные
                Club.Name = this.Name.Text;
                Club.Address = this.Address.Text;
                Club.WorkTime = this.WorkTime.Text;
            }

            // Сохраняем изменения
            this.Main.AllClub.SaveChanges();

            // Открываем страницу клубов
            MainWindow.init.OpenPages(new Pages.Clubs.Main());
        }
    }
}