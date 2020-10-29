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
using System.Runtime.Caching;

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
        [CacheOutput(ServerTimeSpan = 600)]
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

        [Route("getAll/summarized")]
        [HttpGet]
        [CacheOutput(ServerTimeSpan = 600)]
        public async Task<IHttpActionResult> SummarizeTradesByAll()
        {
            try
            {
                var trades = await _tradesRepository.SummarizeByAll();
                return Ok(trades);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("getAll/summarized/ticker")]
        [HttpGet]
        [CacheOutput(ServerTimeSpan = 600)]
        public async Task<IHttpActionResult> SummarizeTradesByTicker()
        {
            try
            {
                var trades = await _tradesRepository.SummarizeByTicker();
                return Ok(trades);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("getAll/summarized/side")]
        [HttpGet]
        [CacheOutput(ServerTimeSpan = 600)]
        public async Task<IHttpActionResult> SummarizeTradesBySide()
        {
            try
            {
                var trades = await _tradesRepository.SummarizeBySide();
                return Ok(trades);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("getAll/summarized/account")]
        [HttpGet]
        [CacheOutput(ServerTimeSpan = 600)]
        public async Task<IHttpActionResult> SummarizeTradesByAccount()
        {
            try
            {
                var trades = await _tradesRepository.SummarizeByAccount();
                return Ok(trades);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
