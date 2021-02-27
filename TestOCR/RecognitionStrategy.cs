using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TestOCR.Filters;
using TestOCR.Models;

namespace TestOCR
{
    public static class RecognitionStrategy
    {
        public static string Process(List<string> imageLines)
        {
            var bill = GetBill(imageLines,
                imageLines.Any(x => x.ToLower().Contains("card")) ? Utils.SlipFilters : Utils.BillFilters);

            return JsonConvert.SerializeObject(bill);
        }

        private static Bill GetBill(List<string> imageLines, ArrayList filters)
        {
            var bill = new Bill();

            foreach (Filter filter in filters) filter.Apply(imageLines, bill);

            return bill;
        }
    }
}