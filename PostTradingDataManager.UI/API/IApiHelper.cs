using System.Net.Http;

namespace PostTradingDataManager.UI.API
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }
    }
}