using Newtonsoft.Json;
using PostTradingDataManager.Repository.Interfaces;
using PostTradingDataManager.Repository.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTradingDataManager.Repository
{
    public sealed class TradesRepository : ITradesRepository
    {
        public IEnumerable<FilteredTradesModel> GetFilteredTrades()
        {
            var path = ConfigurationManager.AppSettings.Get("testData");

            try
            {
                using (var sr = new StreamReader(path))
                {
                    var filteredTrades = sr.ReadToEnd();

                    return JsonConvert.DeserializeObject<FilteredTradesCollectionModel>(filteredTrades).TradesCollection;
                }
            } catch (Exception ex)
            {
                throw new Exception("Could not read data file.", ex);
            }
        }

        public IEnumerable<TradeModel> GetTrades()
        {
            var path = ConfigurationManager.AppSettings.Get("testData");

            try
            {
                using (var sr = new StreamReader(path))
                {
                    var trades = sr.ReadToEnd();

                    return JsonConvert.DeserializeObject<TradesCollectionModel>(trades).TradesCollection;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Could not read data file.", ex);
            }
        }
    }
}
