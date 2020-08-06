using System.Collections.Generic;

namespace ConsoleUI
{
    public interface IMeasureRepository
    {
        List<IMeasure> Measures { get; set; }
    }
}