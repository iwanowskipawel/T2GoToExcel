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
            foreach (var m in repo.Measures)
            {
                int currentRow = 1;
                Worksheet sheet = (Worksheet)template.Worksheets[1];
                List<double> frictionFactors = m.GetFrictionFactors();
                foreach (var f in frictionFactors)
                {
                    sheet.Cells[currentRow++, "B"] = f;
                }

                template.SaveAs(m.GetFileName());
            }

            template.Close();
        }
    }
}
