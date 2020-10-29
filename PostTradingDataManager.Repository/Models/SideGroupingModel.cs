using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTradingDataManager.Repository.Models
{
    public sealed class SideGroupingModel
    {
        public char Side { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
