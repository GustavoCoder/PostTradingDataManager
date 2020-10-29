using PostTradingDataManager.Repository.Models;
using PostTradingDataManager.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTradingDataManager.Repository.Interfaces
{
    public interface ITradesRepository
    {
        Task<IEnumerable<TradeModel>> GetTrades();
        Task<IEnumerable<GroupingModel>> SummarizeByAll();
        Task<IEnumerable<TickerGroupingModel>> SummarizeByTicker();
        Task<IEnumerable<SideGroupingModel>> SummarizeBySide();
        Task<IEnumerable<AccountGroupingModel>> SummarizeByAccount();
    }
}
