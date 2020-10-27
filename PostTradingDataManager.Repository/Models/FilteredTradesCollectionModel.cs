using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTradingDataManager.Repository.Models
{
    public class FilteredTradesCollectionModel
    {
        public IEnumerable<FilteredTradesModel> TradesCollection { get; set; }
    }
}
