using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyScraper
{
    public class CurrencyValidator
    {
        
        //Checks if currency name provided by user exists
        public static bool IsCurrencyAvailable(HtmlDocument htmlDocument, string currency)
        {
            var currencyNames = GetCurrencyNames(htmlDocument);

            if (currencyNames.Contains(currency.ToUpper()))
                return true;
            else
            {
                ScraperMessages.CurrencyNotFound(currencyNames.ToList());
                return false;
            }
        }

        //This method finds all elements on page that are type option and returns collection made of innerhtml of those elements
        public static IEnumerable<string> GetCurrencyNames(HtmlDocument htmlDocument)
        {
            var currencyOptions = htmlDocument.DocumentNode.Descendants("option")
                .ToList();

            foreach (var item in currencyOptions)
                yield return item.InnerHtml;
        }
    }
}
