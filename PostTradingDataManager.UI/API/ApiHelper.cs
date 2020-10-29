using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PostTradingDataManager.UI.API
{
    public static class ApiHelper
    {
        private static HttpClient _apiClient;
        public static HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
        }

        private static void Initizalize()
        {
            string api = ConfigurationManager.AppSettings["getall"];

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
        }
    }
}
