using System.Collections.Generic;
using System.Linq;
using TestOCR.Models;

namespace TestOCR.Filters
{
    public class SlipPriceFilter : Filter
    {
        public override void Apply(List<string> parsedText, Bill slip)
        {
            var price = Utils.DecimalPatternRegex
                .Match(parsedText.SingleOrDefault(x => x.ToLower().Contains("iznos")) ?? string.Empty).ToString();

            slip.Price = price;
        }
    }
}