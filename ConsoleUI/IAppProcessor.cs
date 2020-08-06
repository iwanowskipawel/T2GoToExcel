using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace ConsoleUI
{
    public interface IAppProcessor
    {
        List<IMeasure> LoadMeasureFiles(List<string> paths);
        void SaveMeasureFilesInExcel(IMeasureRepository repo, Workbook template);
    }
}