using System.Collections.Generic;

namespace ConsoleUI
{
    public interface IMeasure
    {
        short DragHi { get; set; }
        byte DragLo { get; set; }
        List<short> Friction { get; set; }
        string OriginalPath { get; set; }

        string GetFileName();
        List<double> GetFrictionFactors();
    }
}