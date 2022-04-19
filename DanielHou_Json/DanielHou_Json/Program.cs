using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DanielHou_Json
{
	class Program
	{
		static void Main(string[] args)
		{
			string chinadownload, usadownload, indiadownload;
            using(var wc = new WebClient())
            {
                chinadownload = wc.DownloadString("http://api.worldbank.org/v2/countries/CHN/indicators/SP.POP.TOTL?per_page=5000&format=json");
				usadownload = wc.DownloadString("http://api.worldbank.org/v2/countries/USA/indicators/SP.POP.TOTL?per_page=5000&format=json");
				indiadownload = wc.DownloadString("http://api.worldbank.org/v2/countries/IND/indicators/SP.POP.TOTL?per_page=5000&format=json");
            }
			List<PopulationData> china = new List<PopulationData> { };
			List<PopulationData> usa = new List<PopulationData> { };
			List<PopulationData> india = new List<PopulationData> { };
			dynamic j = JArray.Parse(chinadownload);
			dynamic l = j[1];
			foreach (dynamic row in l)
			{
				Console.WriteLine($"{row["countryiso3code"]}, {row["value"]}, {row["date"]}");
				PopulationData p = new PopulationData(row["countryiso3code"], row["value"], row["date"]);
				china.Add(p);
			}
			j = JArray.Parse(usadownload);
			l = j[1];
			foreach (dynamic row in l)
			{
				Console.WriteLine($"{row["countryiso3code"]}, {row["value"]}, {row["date"]}");
				PopulationData p = new PopulationData(row["countryiso3code"], row["value"], row["date"]);
				usa.Add(p);
			}
			j = JArray.Parse(indiadownload);
			l = j[1];
			foreach (dynamic row in l)
			{
				Console.WriteLine($"{row["countryiso3code"]}, {row["value"]}, {row["date"]}");
				PopulationData p = new PopulationData(row["countryiso3code"], row["value"], row["date"]);
				india.Add(p);
			}

			Console.ReadKey();
		}

		public class PopulationData
		{
			public string _country;
			public int _population;
			public int _year;

			public string Country { get => _country; set => _country = value; }
			public int Population { get => _population; set => _population = value; }
			public int Year { get => _year; set => _year = value; }

			public PopulationData(dynamic c, dynamic p, dynamic y)
			{
				_country = c;
				_population = p;
				_year = y;
			}
		}
	}
}
