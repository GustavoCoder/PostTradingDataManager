using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTradingDataManager.Repository.Models
{
    public class TradesCollectionModel
    {
        public IEnumerable<TradeModel> TradesCollection { get; set; }
    }
}
