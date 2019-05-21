using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradePMR.DanielSerrano.Common;
using TradePMR.DanielSerrano.Data;
using TradePMR.DanielSerrano.Data.Interfaces;
using TradePMR.DanielSerrano.Data.Models;
using TradePMR.DanielSerrano.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradePMR.DanielSerrano.WebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TradePMRDbContext Context;
        private readonly IAccountRepository Repo;

        public AccountsController(TradePMRDbContext context)
        {
            Context = context;
            Repo = new AccountRepository(context);
        }

        // GET api/<controller>/5
        [HttpGet]
        public IActionResult Get([FromQuery] AccountQueryParameter p)
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
        public IActionResult Post([FromBody]Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                Repo.Validate(account);
            }
            catch (Exception xe)
            {
                return BadRequest(xe);
            }
            return Ok(Repo.Add(account));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Account account)
        {
            account.Id = id;
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            account = Repo.Update(account);
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var account = Repo.Delete(id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }
    }
}
