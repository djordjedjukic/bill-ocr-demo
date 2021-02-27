using System.Collections.Generic;
using System.Linq;
using TestOCR.Models;

namespace TestOCR.Filters
{
    public class PaymentTypeFilter : Filter
    {
        public override void Apply(List<string> parsedText, Bill bill)
        {
            var isCard = parsedText.Any(x => x.ToLower().Contains("kartic") || x.ToLower().Contains("card"));

            bill.PaymentType = isCard ? Utils.Card : Utils.Cash;
        }
    }
}