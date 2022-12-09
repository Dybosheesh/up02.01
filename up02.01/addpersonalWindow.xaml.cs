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
using System.Windows.Shapes;

namespace up02._01
{
    /// <summary>
    /// Логика взаимодействия для addpersonalWindow.xaml
    /// </summary>
    public partial class addpersonalWindow : Window
    {
        AppContext db;

        public addpersonalWindow()
        {
            InitializeComponent();

            db = new AppContext();
        }

        private void savebutton_Click(object sender, RoutedEventArgs e)
        {
            string ident = TBident.Text.Trim();
            string name = TBname.Text.Trim();
            string surname = TBsurname.Text.Trim();
            string patronymic = TBpatronymic.Text.Trim();
            string post = TBpost.Text.Trim();

            if (ident.Length < 0)
            {
                TBident.ToolTip = "Поле заполнено некорректно";
                TBident.Background = Brushes.DarkRed;
            }
            else
            {
                TBident.ToolTip = "";
                TBident.Background = Brushes.Transparent;

                Personal personal = new Personal(ident, name, surname, patronymic, post);

                db.personals.Add(personal);
                db.SaveChanges();
                Hide();
            }

        }
    }
}
