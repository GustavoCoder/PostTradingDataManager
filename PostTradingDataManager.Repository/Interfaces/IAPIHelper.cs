using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PostTradingDataManager.Repository.Interfaces
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
    }
}
