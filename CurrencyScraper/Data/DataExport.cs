using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace CurrencyScraper
{
    public class DataExport
    {

        //This method exports provided data to CSV file with location set in App.config
        public static void Export(List<List<string>> currencyData, string currency)
        {
            using (var writer = new StreamWriter(GetFilePath(currency)))
            {
                writer.WriteLine("Currency Name, Buying Rate, Cash Buying Rate, Selling Rate, Cash Selling Rate, Middle Rate, Pub Time");
                foreach (List<string> subList in currencyData.Skip(1))
                {
                    foreach (var item in subList)
                    {
                        writer.Write(item + ", ");
                        writer.Flush();
                    }
                    writer.WriteLine();
                }
            }
            ScraperMessages.DataExported();
        }

        //This method returns file path for saving CSV that can be configured in App.config
        private static string GetFilePath(string currency)
        {
            string filePath = ConfigurationManager.AppSettings["FilePath"];
            return filePath += currency + "-" + DataGenerator.GetDates().Item1 + "-" + DataGenerator.GetDates().Item2 + ".csv";
        }
    }
}
