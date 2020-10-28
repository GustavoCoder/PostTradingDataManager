using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTradingDataManager.Repository.Models
{
    public class SummarizedTradesModel
    {
        public string Ticker { get; set; }
        public string Side { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Account { get; set; }
    }
}
