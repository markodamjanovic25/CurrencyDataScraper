using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyScraper
{
    public class HtmlManager
    {
        //This method sends post request that includes target url and form data provided and returns response as a string
        private static async Task<string> GetHtmlContent(FormUrlEncodedContent formContent)
        {
            var url = "https://srh.bankofchina.com/search/whpj/searchen.jsp";
            HttpClient httpClient = new HttpClient();
            var response = httpClient.PostAsync(url, formContent).Result;
            return await response.Content.ReadAsStringAsync();
        }

        //This method generates HtmlDocument for provided currency
        public static async Task<HtmlDocument> GenerateHtmlDocument(string currency)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(await GetHtmlContent(DataGenerator.Generate(currency)));
            return htmlDocument;
        }
    }
}
