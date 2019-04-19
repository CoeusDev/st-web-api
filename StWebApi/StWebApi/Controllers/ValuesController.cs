using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace StWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConfiguration configuration;
        private IDbConnection connection;

        public ValuesController(IConfiguration configuration, IDbConnection connection)
        {
            this.configuration = configuration;
            this.connection = connection;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pocos.UserAccount>> Get()
        {
            var query = "SELECT * FROM UserAccount";
            var userAccounts = connection.Query<Pocos.UserAccount>(query);
            return userAccounts.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
