using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CurrencyScraper
{
    public class DataGenerator
    {
        //This method populates form fields and returns them ready for sending POST request
        public static FormUrlEncodedContent Generate(string currency)
        {
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("erectDate", GetDates().Item1));
            formData.Add(new KeyValuePair<string, string>("nothing", GetDates().Item2));
            formData.Add(new KeyValuePair<string, string>("pjname", currency));
            return new FormUrlEncodedContent(formData);
        }

        //Defining dates for form data
        public static Tuple<string, string> GetDates()
        {
            var startDate = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd");
            var endDate = DateTime.Now.ToString("yyyy-MM-dd");
            return new Tuple<string, string>(startDate, endDate); 
        }
    }
}
