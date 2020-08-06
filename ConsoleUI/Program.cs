using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
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
