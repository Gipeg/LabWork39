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

namespace Task4
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

            //3.4
            var today = DateTime.Today;
            var filesTodayDirs = from dir in directories
                                 join file in files on dir.FullName equals file.DirectoryName
                                 where dir.CreationTime.Date == today
                                 select file;


            reusltDataGrid.ItemsSource = filesTodayDirs.ToList();
        }
    }
}
