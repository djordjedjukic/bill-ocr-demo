using System.Collections.Generic;
using TestOCR.Models;

namespace TestOCR.Filters
{
    public abstract class Filter
    {
        public abstract void Apply(List<string> imageLines, Bill bill);
    }
}