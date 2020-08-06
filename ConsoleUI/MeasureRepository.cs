using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class MeasureRepository : IMeasureRepository
    {
        public List<IMeasure> Measures { get; set; }
    }
}
