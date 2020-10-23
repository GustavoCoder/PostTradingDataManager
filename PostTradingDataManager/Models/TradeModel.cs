using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostTradingDataManager.Models
{
    public class TradeModel
    {
        public long TradeId { get; set; }
        public DateTime TradeDate { get; set; }
        public char Side { get; set; }
        public string Ticker { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Account { get; set; }
    }
}