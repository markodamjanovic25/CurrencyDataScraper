using HtmlAgilityPack;
using System.Threading.Tasks;

namespace CurrencyScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string currency = ScraperMessages.GetCurrencyName();

            HtmlDocument htmlDocument = await HtmlManager.GenerateHtmlDocument(currency);

            if (CurrencyValidator.IsCurrencyAvailable(htmlDocument, currency))
                DataProcess.Process(htmlDocument, currency);

            ScraperMessages.CloseApplication();
        }
    }
}
