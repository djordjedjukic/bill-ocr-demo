using System.Collections.Generic;
using TestOCR.Models;

namespace TestOCR.Filters
{
    public class StoreFilter : Filter
    {
        public override void Apply(List<string> imageLines, Bill bill)
        {
            foreach (var line in imageLines)
            foreach (var storeType in Utils.StoreTypes)
                if (line.ToLower().Replace(".", "").Replace(" ", "").Contains(storeType))
                {
                    bill.Store = line;
                    break;
                }
        }
    }
}