using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TradePMR.DanielSerrano.Common;
using TradePMR.DanielSerrano.Data;
using TradePMR.DanielSerrano.Data.Interfaces;
using TradePMR.DanielSerrano.Data.Models;
using TradePMR.DanielSerrano.Data.Repositories;
using TradePMR.DanielSerrano.Data.Validators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradePMR.DanielSerrano.WebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {
        private readonly ITradeRepository Repo;
        private readonly TradePMRDbContext Context;

        public TradesController(TradePMRDbContext context)
        {
            Context = context;
            Repo = new TradeRepository(context);
        }

        // GET api/<controller>
        [HttpGet]
        public IActionResult Get([FromQuery] TradeQueryParameter p)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Repo.Query(p));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var trade = Repo.GetById(id);
            if (trade == null)
                return NotFound();
            return Ok(Repo.GetById(id));
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Trade trade)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                Repo.Validate(trade);
            }
            catch(Exception xe)
            {
                return BadRequest(xe);
            }
            return Ok(Repo.Add(trade));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PutTradeParameter putTrade)
        {
            putTrade.Id = id;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var validator = new PutTradeValidator(Context, putTrade);
            var result = validator.Validate();
            if(result.Any())
            {
                return BadRequest(result);
            }

            var trade = Repo.Update(putTrade);
            if (trade == null)
                return NotFound();
            return Ok(trade);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var trade = Repo.Delete(id);
            if (trade == null)
                return NotFound();
            return Ok(trade);
        }
    }
}
