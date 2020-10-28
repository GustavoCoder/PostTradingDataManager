using Newtonsoft.Json;
using PostTradingDataManager.Repository.Interfaces;
using System;
using WebApi.OutputCache.V2;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PostTradingDataManager.UI;

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

        [Route("getAll")]
        [HttpGet]
        [CacheOutput(ServerTimeSpan = 120)]
        public async Task<IHttpActionResult> GetAllTrades()
        {
            try
            {
                var trades = await _tradesRepository.GetTrades();
                return Ok(trades);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
