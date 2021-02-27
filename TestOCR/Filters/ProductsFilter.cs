using System;
using System.Collections.Generic;
using System.Linq;
using TestOCR.Models;

namespace TestOCR.Filters
{
    public class ProductsFilter : Filter
    {
        public override void Apply(List<string> imageLines, Bill bill)
        {
            var products = new List<Tuple<string, string>>();

            for (int i = 0; i < imageLines.Count; i++)
            {
                if (Utils.ProductPricePatternRegex.Match(imageLines[i]).Success)
                {
                    products.Add(Tuple.Create(imageLines[i], imageLines[i - 1]));
                }
            }

            foreach (var productLine in products)
            {
                var parsedPriceData = productLine.Item1.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToArray();

                var amount = parsedPriceData[0].Split("x")[0]; 
                var singlePrice = parsedPriceData[0].Split("x")[1];

                var product = new Product
                {
                    Name = productLine.Item2,
                    Amount = Convert.ToInt32(amount),
                    Price = singlePrice
                };

                bill.Products.Add(product);
            }
        }
    }
}