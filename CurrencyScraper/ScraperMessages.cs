using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyScraper
{
    public class ScraperMessages
    {
        //Getting currency name that users wants to see data for
        public static string GetCurrencyName()
        {
            Console.WriteLine("Enter currency abbreviation you want to see data for:");
            return Console.ReadLine();
        }

        public static void CurrencyNotFound(List<string> currencyNames)
        {
            Console.WriteLine("You have not entered any of available currencies.");
            Console.WriteLine("Currencies available:");
            foreach (var item in currencyNames.Skip(1))
                Console.WriteLine(item);
        }

        public static void CurrencyNoData()
        {
            Console.WriteLine("Sorry, there is no available data for that currency!");
        }

        public static string ExportToCsvPrompt()
        {
            Console.WriteLine("\nWould you like to export data to CSV file? (y/n)");
            return Console.ReadLine();
        }

        public static void DataExported()
        {
            Console.WriteLine("Data exported to CSV!");
        }

        public static void CloseApplication()
        {
            Console.WriteLine("\nPress enter to close...");
            Console.ReadLine();
        }
    }
}
