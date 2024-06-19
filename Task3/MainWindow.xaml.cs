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
using System.IO;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData(@"F:\LabWork39_Чугин");
        }


        private void LoadData(string path)
        {
            DirectoryInfo direct = new(path);
            FileInfo[] files = direct.GetFiles("*", SearchOption.AllDirectories);
            var directories = direct.GetDirectories();

            var filesByMonth = files.GroupBy(f => new { f.CreationTime.Year, f.CreationTime.Month })
            .Select(g => new
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                Count = g.Count()
            }).ToList();

            reusltDataGrid.ItemsSource = filesByMonth.ToList();
        }
    }
}
