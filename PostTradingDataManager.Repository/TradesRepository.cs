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
        private IEnumerable<TradeModel> _loadedTrades;

        public async Task<IEnumerable<TradeModel>> GetTrades()
        {
            var path = ConfigurationManager.AppSettings.Get("testData");

            try
            {
                using (var sr = new StreamReader(path))
                {
                    var trades = await sr.ReadToEndAsync();

                    _loadedTrades = JsonConvert.DeserializeObject<TradesCollectionModel>(trades).TradesCollection;

                    return _loadedTrades;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GroupingModel>> SummarizeByAll()
        {

            try
            {
                    var result = await Task.Run(() => from item in _loadedTrades
                                                      group item by new { item.Ticker, item.Side, item.Account } into g
                                         orderby g.Key.Account, g.Key.Ticker, g.Key.Side
                                         select new GroupingModel
                                         {
                                             Ticker = g.Key.Ticker,
                                             Side = g.Key.Side,
                                             Account = g.Key.Account,
                                             Quantity = g.Sum(x => x.Quantity),
                                             Price = Math.Round(g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity)), 4)
                                         });

                    return result;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TickerGroupingModel>> SummarizeByTicker()
        {
            try
            {
                var result = await Task.Run(() => from item in _loadedTrades
                                                  group item by new { item.Ticker } into g
                                     orderby g.Key.Ticker
                                     select new TickerGroupingModel
                                     {
                                         Ticker = g.Key.Ticker,
                                         Quantity = g.Sum(x => x.Quantity),
                                         Price = Math.Round(g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity)), 4)
                                     });

                return result;
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<SideGroupingModel>> SummarizeBySide()
        {
            try
            {
                var result = await Task.Run(() => from trade in _loadedTrades
                                                  group trade by new { trade.Side } into g
                                     orderby g.Key.Side
                                     select new SideGroupingModel
                                     {
                                         Side = g.Key.Side,
                                         Quantity = g.Sum(x => x.Quantity),
                                         Price = Math.Round(g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity)), 4)
                                     });

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AccountGroupingModel>> SummarizeByAccount()
        {
            try
            {
                var result = await Task.Run(() => from trade in _loadedTrades
                                                  group trade by new { trade.Account } into g
                                     orderby g.Key.Account
                                     select new AccountGroupingModel
                                     {
                                         Account = g.Key.Account,
                                         Quantity = g.Sum(x => x.Quantity),
                                         Price = Math.Round(g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity)), 4)
                                     });

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
