using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TestOCR.Models;

namespace TestOCR.Filters
{
    public class BillPriceFilter : Filter
    {
        public override void Apply(List<string> parsedText, Bill bill)
        {
            var price = Utils.PricePatternRegex
                .Match(parsedText.SingleOrDefault(x => x.ToLower().Contains("uplat")) ?? string.Empty).ToString();

            bill.Price = price;
        }
    }
}