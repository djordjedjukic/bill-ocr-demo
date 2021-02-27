using System.Collections;
using System.Text.RegularExpressions;
using TestOCR.Filters;

namespace TestOCR
{
    public static class Utils
    {
        public static string[] DateFormats =
        {
            "dd/MM/yyyy",
            "d/M/yyyy",
            "dd/mm/yy",
            "d/m/yy",

            "dd-MM-yyyy",
            "d-M-yyyy",
            "dd-MM-yy",
            "d-M-yy",

            "dd.MM.yyyy",
            "d.M.yyyy",
            "dd.MM.yy",
            "d.M.yy",

            "dd MM yyyy",
            "d M yyyy",
            "dd MM yy",
            "d M yy",
        };
        
        public static Regex DatePatternRegex = new Regex(@"(\d{1,4}([.\-/])\d{1,2}([.\-/])\d{1,4})");
        
        public static Regex PricePatternRegex = new Regex(@"(?:\d+\.)?\d+,\d+");
        
        public static Regex ProductPricePatternRegex = new Regex(@"\d+([x])(?:\d+\.)?\d+,\d+");
        
        public static Regex DecimalPatternRegex = new Regex(@"\d+(\.\d+)?");
        
        public const string Card = "Card";
        
        public const string Cash = "Cash";
        
        public static string[] StoreTypes =
        {
            "doo",
            "szr",
            "kd",
            "radnja"
        };
        
        public static ArrayList BillFilters = new ArrayList
        {
            new DateFilter(), new BillPriceFilter(), new PaymentTypeFilter(), new StoreFilter(), new ProductsFilter()
        };
        
        public static ArrayList SlipFilters = new ArrayList
        {
            new DateFilter(), new SlipPriceFilter(), new StoreFilter(), new PaymentTypeFilter()
        };
    }
}