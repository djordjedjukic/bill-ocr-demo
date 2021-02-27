using System;
using System.Collections.Generic;
using System.Globalization;
using TestOCR.Models;

namespace TestOCR.Filters
{
    public class DateFilter : Filter 
    {
        public override void Apply(List<string> imageLines, Bill bill)
        {
            var parsedDate = "";

            foreach (var line in imageLines)
            {
                var match = Utils.DatePatternRegex.Match(line);
                if (!match.Success) continue;
                parsedDate = match.Value;
                imageLines.Remove(line);
                break;
            }

            if (DateTime.TryParseExact(parsedDate, Utils.DateFormats, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out var date))
            {
                bill.PurchaseDate = date;
            }
        }  
    }
}