using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyScraper
{
    public class DataProcess
    {
        //If there is any data in the table, this method prints it to the console, and depending on user input, exports it to CSV
        public static void Process(HtmlDocument htmlDocument, string currency)
        {
            var currencyTable = GetTable(htmlDocument);

            //Checks if table is showing any data
            if (currencyTable.Count > 0)
            {
                var currencyData = Print(currencyTable);
                //Checks if user wants to export data to CSV
                if (ScraperMessages.ExportToCsvPrompt() == "y")
                    DataExport.Export(currencyData, currency);
            }
            else
                ScraperMessages.CurrencyNoData();
        }

        //This method prints table data to the console and returns it
        private static List<List<string>> Print(List<HtmlNode> currencyTable)
        {
            //Gets all child elements of table provided marked as "tr"
            var tableRows = currencyTable[0].Descendants("tr")
                            .ToList();

            List<List<string>> currencyData = new List<List<string>>();

            //Loops through each "tr" element to get its "td" elements values
            foreach (var item in tableRows)
            {
                List<string> tableCells = new List<string>();
                foreach (var td in item.Descendants("td"))
                {
                    Console.Write(td.InnerHtml + " ");
                    tableCells.Add(td.InnerHtml);
                }
                currencyData.Add(tableCells);
                //New line after each row
                Console.WriteLine();
            }
            return currencyData;
        }

        //Gets all elements of document that are marked as "table" and have bgcolor attribute set to "#EAEAEA"
        private static List<HtmlNode> GetTable(HtmlDocument htmlDocument)
        {
            return htmlDocument.DocumentNode.Descendants("table")
                .Where(node => node.GetAttributeValue("bgcolor", "").Equals("#EAEAEA"))
                .ToList();
        }

    }
}
