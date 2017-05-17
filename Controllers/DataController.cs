using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mongo_aspnet_api.Controllers
{
     [Route("api/[controller]")]
    public class DataController  : Controller
    {
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.Run(() =>  Ok(JsonConvert.SerializeObject(new {Time = "Hello World"}, Formatting.Indented)));
        }
    }
}