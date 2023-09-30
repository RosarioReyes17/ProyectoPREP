using Microsoft.Web.Administration;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace ProyectoPREP.Padron
{
	public class Query_Padron_Imp
	{

		public static Padron_Imp Query_Imp(string _no_doc)
		{
			

			try
			{
				var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
				var url = MyConfig.GetValue<string>("ImpUri");


				string _key = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
				string _searchItem = Base64Encode(_no_doc + _key);
				string _imp_uri = url;
				string _json = new WebClient() { Encoding = Encoding.UTF8 }.DownloadString(_imp_uri + _searchItem);

				Padron_Imp _data = JsonConvert.DeserializeObject<Padron_Imp>(_json);
				return _data;

			}
			catch (Exception ex)
			{
				return new Padron_Imp();
			}

		}

		public static string Base64Encode(string plainText)
		{
			var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
			return System.Convert.ToBase64String(plainTextBytes);
		}
	}
}
