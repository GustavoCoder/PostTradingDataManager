﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTradingDataManager.Repository.Models
{
    public sealed class TradeModel
    {
        public long TradeId { get; set; }
        public DateTime TradeDate { get; set; }
        public int Account { get; set; }
        public string Ticker { get; set; }
        public char Side { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
