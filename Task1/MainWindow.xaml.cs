using System;
using System.Linq;
using System.Windows;
using System.IO;

namespace Task1
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
            var files = directory.GetFiles("*", SearchOption.AllDirectories);

            var directories = directory.GetDirectories();

            //3.1
            var filesAndDirs = files.Select(f => new { Name = f.Name, DataCreated = f.CreationTime, Extension = f.Extension, Year = f.CreationTime.Year })
                .Union(directories.Select(d => new { Name = d.Name, DataCreated = d.CreationTime, Extension = d.Extension, Year = d.CreationTime.Year }));

            

            
            

            // 3.5

            var filesCountByDir = directories.GroupJoin(files, dir => dir.FullName, file => file.DirectoryName,
                (dir, dirFiles) => new
                {
                    DirectoryName = dir.Name,
                    FileCount = dirFiles.Count()
                });

            reusltDataGrid.ItemsSource = filesAndDirs.ToList(); 
           
        }
    }
}
