using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IngaiaService02.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyValueController : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {

            return Ok(await "https://account.educadventista.org/api/v1/person/989ef010-3b07-4f01-953a-a9a70058857d/followup"

                                            .GetAsync()
                                            .ReceiveJson());

        }

        [HttpGet("generate")]
        public async Task<ActionResult> GetGeneratePropertyValueAsync(double meter)
        {
            var resultApi = await "https://localhost:5001/propertyCategory"
                                         .GetAsync()
                                         .ReceiveJson();
            return Ok((double)resultApi.value * meter);

        }
    }
}
