using System.Linq;
using System.Xml.Linq;

namespace ConsoleUI
{
    public static class MeasureImporter
    {
        public static IMeasure Load(string path)
        {
            IMeasure measure = new Measure();

            XDocument xmlFile = XDocument.Load(path);
            measure.DragHi = short.Parse(xmlFile.Descendants("DragHi").First().Value);
            measure.DragLo = byte.Parse(xmlFile.Descendants("DragLo").First().Value);

            foreach (var f in xmlFile.Descendants("Friction"))
            {
                measure.Friction.Add(short.Parse(f.Value));
            }

            measure.OriginalPath = path;

            return measure;
        }
    }
}
