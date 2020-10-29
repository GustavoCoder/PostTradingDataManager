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
        Task<IEnumerable<TradeModel>> SummarizeByAll();
        Task<IEnumerable<TradeModel>> SummarizeByTicker();
        Task<IEnumerable<TradeModel>> SummarizeBySide();
        Task<IEnumerable<TradeModel>> SummarizeByAccount();
    }
}
