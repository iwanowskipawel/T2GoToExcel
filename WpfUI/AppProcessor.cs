using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class AppProcessor : IAppProcessor
    {
        public List<IMeasure> LoadMeasureFiles(List<string> paths)
        {
            List<IMeasure> measures = new List<IMeasure>();

            foreach (var p in paths)
            {
                IMeasure m = MeasureImporter.Load(p);
                measures.Add(m);
            }

            return measures;
        }

        

        public Workbook LoadTemplateFile(string path)
        {
            Application app = new Application();
            app.Visible = false;
            Workbook workbook = app.Workbooks.Open(path);

            return workbook;
        }

        public void SaveMeasureFilesInExcel(IMeasureRepository repo, Workbook template)
        {
            Application excel = new Application();
            Workbook temp = excel.Workbooks.Open(@"C:\Users\pawel.iwanowski\Desktop\test\template.xlsx");

            foreach (var m in repo.Measures)
            {
                int currentRow = 1;
                Worksheet sheet = (Worksheet)temp.Worksheets[1];
                List<double> frictionFactors = m.GetFrictionFactors();
                foreach (var f in frictionFactors)
                {
                    sheet.Cells[currentRow++, "B"].Value = f;
                }
                Console.WriteLine($"Excel value = {sheet.Cells[5, "B"]}");
                //template.SaveAs(m.GetFileName());
                //temp.SaveAs(@"C:\test");
            }

            temp.Close();
        }
    }
}
