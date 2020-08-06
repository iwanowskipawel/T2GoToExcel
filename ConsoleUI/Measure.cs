using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class Measure : IMeasure
    {
        public string OriginalPath { get; set; }
        public short DragHi { get; set; }

        public byte DragLo { get; set; }

        public List<short> Friction { get; set; } = new List<short>();

        public string GetFileName()
        {
            return OriginalPath
                .Remove(OriginalPath.LastIndexOf('\\'))
                .Replace(".MEASURE", "");
        }

        public List<double> GetFrictionFactors()
        {
            List<double> factors = new List<double>();

            foreach (var f in Friction)
            {
                factors.Add(CalculateFrictionFactor(f));
            }

            return factors;
        }

        double CalculateFrictionFactor(short friction)
        {
            return Math.Round((double)((friction - DragLo) / (DragHi - DragLo)), 3);
        }
    }
}
