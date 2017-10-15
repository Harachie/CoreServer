using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreServer.Models;
using CoreServer.Code;
using Newtonsoft.Json.Linq;

namespace CoreServer.Controllers
{
    [Route("api/[controller]")]
    public class MapsController : Controller
    {
        [HttpGet]
        public ApiAnswer GetAllMaps()
        {
            ApiAnswer r = new ApiAnswer() { Success = true };


            return r;
        }

        [HttpPost("createMap")]
        public async Task<ApiAnswer> CreateMapAsync([FromBody] CreateMapModel model)
        {
            ApiAnswer r = new ApiAnswer();
            JObject createOperation;

            if (model is null)
            {
                return r;
            }

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return r;
            }

            createOperation = await Repository.Rethink.CreateTableAsync(model.Name);
            r.Success = true;
            r.Value = createOperation;

            return r;
        }
    }
}