using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mongo_aspnet_api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IMongoAsyncRepository<DateCounter> _repo;

        public ValuesController(IMongoAsyncRepository<DateCounter> repo){
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var all = await Task.Run(() =>  _repo.GetAll());

            var e = new DateCounter()
            {
                LastCount = DateTime.Now,
                Count = 1
            };

            if (all.Any())
            {
                e = new DateCounter()
                {
                    LastCount = DateTime.Now,
                    Count = all.Last().Count + 1
                };
            }

            await Task.Run(() => _repo.Add(e));

            return await Task.Run(() =>  Ok(JsonConvert.SerializeObject(new {Time = e.LastCount, Count = e.Count}, Formatting.Indented)));
        }


    }
}
