using Newtonsoft.Json;
using PostTradingDataManager.Repository.Interfaces;
using PostTradingDataManager.Repository.Models;
using PostTradingDataManager.UI;
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

        public async Task<IEnumerable<TradeModel>> GetTrades()
        {
            var path = ConfigurationManager.AppSettings.Get("testData");

            try
            {
                using (var sr = new StreamReader(path))
                {
                    var trades = await sr.ReadToEndAsync();

                    return JsonConvert.DeserializeObject<TradesCollectionModel>(trades).TradesCollection;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TradeModel>> GroupTradesByAll()
        {
            var path = ConfigurationManager.AppSettings.Get("testData");

            try
            {
                using (var sr = new StreamReader(path))
                {
                    var content = await sr.ReadToEndAsync();

                    var tradesList = JsonConvert.DeserializeObject<TradesCollectionModel>(content).TradesCollection;

                    var result = await Task.Run(() => from item in tradesList
                                                      group item by new { item.Ticker, item.Side, item.Account } into g
                                         orderby g.Key.Account, g.Key.Ticker, g.Key.Side
                                         select new TradeModel
                                         {
                                             Ticker = g.Key.Ticker,
                                             Side = g.Key.Side,
                                             Account = g.Key.Account,
                                             Quantity = g.Sum(x => x.Quantity),
                                             Price = g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity))
                                         });

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
