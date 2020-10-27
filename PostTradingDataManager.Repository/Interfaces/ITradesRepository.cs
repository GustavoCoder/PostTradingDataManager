using PostTradingDataManager.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTradingDataManager.Repository.Interfaces
{
    public interface ITradesRepository
    {

        IEnumerable<TradeModel> GetTrades();

        IEnumerable<FilteredTradesModel> GetFilteredTrades();
    }
}
