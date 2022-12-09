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

namespace up02._01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Personal> PersonalList = new List<Personal>();
            using (var db = new AppContext())
            {
                var query = from b in db.personals select b;
                foreach (var item in query)
                {
                    PersonalList.Add(item);
                }
            }
            personalgrid.ItemsSource = PersonalList;
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            addpersonalWindow addpersonalWindow= new addpersonalWindow();
            addpersonalWindow.Show();
        }

        private void reload_Click(object sender, RoutedEventArgs e)
        {
            List<Personal> PersonalList = new List<Personal>();
            using (var db = new AppContext())
            {
                var query = from b in db.personals select b;
                foreach (var item in query)
                {
                    PersonalList.Add(item);
                }
            }
            personalgrid.ItemsSource = PersonalList;
        }
    }
}
