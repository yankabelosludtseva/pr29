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

namespace пр_29.Pages.Clubs.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        /// <summary> Главная страница клубов
        Main Main;
        /// <summary> Данные клуба
        Models.Clubs Club;

        /// <summary>
        /// Присваиваем наименование
        /// this.Name.Text = Club.Name;
        /// </summary>
        /// <param name="address">Адрес</param>
        /// <param name="workTime">Время работы</param>
        /// <param name="main">Имя клуба</param>
        /// <param name="club">Клуб</param>
        private void EditClub(object sender, System.Windows.RoutedEventArgs e) =>
            // Открываем страницу добавления, пересылая данные
            MainWindow.init.OpenPages(new Pages.Clubs.Add(this.Main, this.Club));

        /// <summary> Метод удаления
        /// <summary>
        /// Удаляем клуб из контекста
        /// Main.AllClub.Clubs.Remove(Club);
        /// </summary>
        /// <param name="name">Имя клуба</param>
        /// <returns></returns>
        public void DeleteClub(object sender, System.Windows.RoutedEventArgs e)
        {
            // Удаляем клик из контекста
            Main.AllClub.Clubs.Remove(Club);
            // Сохраняем изменения
            Main.AllClub.SaveChanges();
            // Удаляем элемент со страницы Main
            Main.Parent.Children.Remove(this);
        }
    }
}
