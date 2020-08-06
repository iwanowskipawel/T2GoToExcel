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

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            //setup application

            IMeasureRepository _repository = new MeasureRepository();
            IAppProcessor _app = new AppProcessor();

            //get measure data

            Console.WriteLine("Type file path of MEASURE:");
            List<string> paths = new List<string>();

            paths.Add(Console.ReadLine());
            _repository.Measures = _app.LoadMeasureFiles(paths);

            //copy to excel file

            Console.WriteLine("Type file path of template:");
            //string templatePath = Console.ReadLine();
            Application excel = new Application();
            //Workbook template = excel.Workbooks.Open(templatePath);
            Workbook template = excel.Workbooks.Open(@"C:\Users\pawel.iwanowski\Desktop\test\template.xlsx");
            _app.SaveMeasureFilesInExcel(_repository, template);

            //display collected data

            foreach (var measure in _repository.Measures)
            {
                Console.WriteLine($"DragHi = {measure.DragHi}");
                Console.WriteLine($"DragLo = {measure.DragLo}");

                Console.WriteLine("Friction:");
                foreach (var f in measure.Friction)
                {
                    Console.WriteLine($"{f}");
                }

            }

            Console.ReadLine();
        }
    }
}
