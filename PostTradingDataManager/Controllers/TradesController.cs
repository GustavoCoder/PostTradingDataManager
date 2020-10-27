using Newtonsoft.Json;
using PostTradingDataManager.Caching;
using PostTradingDataManager.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PostTradingDataManager.Controllers
{
    [RoutePrefix("api/trades")]
    public class TradesController : ApiController
    {
        private readonly ITradesRepository _tradesRepository;

        public TradesController(ITradesRepository tradesRepository)
        {
            _tradesRepository = tradesRepository;
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAllTrades()
        {
            try
            {
                var trades = _tradesRepository.GetTrades();

                return Ok(trades);
            }
            catch (Exception ex)
            {
                throw new Exception($"Bad request. {ex.Message}");
            }

        }

        [Route("filteredtrades")]
        [HttpGet]
        [CacheHelper(Duration = 1)]
        public IHttpActionResult GetFilteredTrades()
        {
            try
            {
                var filteredTrades = _tradesRepository.GetFilteredTrades();
                return Ok(filteredTrades);

            } catch (Exception ex)
            {
                throw new Exception($"Bad request. {ex.Message}");
            }
        }
    }
}
