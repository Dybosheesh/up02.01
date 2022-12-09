using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
using OfficeOpenXml;
using Newtonsoft.Json;
using OfficeOpenXml.Style;


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

        private void excel_Click(object sender, RoutedEventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet sheet = excel.Workbook.Worksheets.Add("Sheet 1");
                sheet.Cells[1, 1].Value = "ID"; ;
                sheet.Cells[1, 2].Value = "IDent";
                sheet.Cells[1, 3].Value = "Имя";
                sheet.Cells[1, 4].Value = "Фамилия";
                sheet.Cells[1, 5].Value = "Отчество";
                sheet.Cells[1, 6].Value = "Должность";
                List<Personal> PersonalList = new List<Personal>();
                using (var db = new AppContext())
                {
                    var query = from b in db.personals select b;
                    foreach (var item in query)
                    {
                        PersonalList.Add(item);
                    }
                }
                sheet.Cells[2, 1].LoadFromCollection(PersonalList);
                string Path = "PersonalList.xlsx";
                FileInfo file_excel = new FileInfo(Path);
                excel.SaveAs(file_excel);
            }
        }

        private void json_Click(object sender, RoutedEventArgs e)
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
            var json_file = JsonConvert.SerializeObject(PersonalList);
            File.WriteAllText("PersonalList.json", json_file.ToString());
        }
    }
}
