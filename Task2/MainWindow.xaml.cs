using System;
using System.IO;
using System.Linq;
using System.Windows;
namespace Task2
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
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);
            DirectoryInfo[] directories = directory.GetDirectories("*", SearchOption.AllDirectories);


            //3.2
            var filesExtensions = files.GroupBy(f => f.Extension)
                .Select(g => new
                {
                    Extension = g.Key,
                    TotalSize = g.Sum(f => f.Length),
                    Count = g.Count()
                }).ToList();



            reusltDataGrid.ItemsSource = filesExtensions.ToList();
        }


        
    }
}
