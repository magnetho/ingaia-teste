using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using IngaiaService02.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IngaiaService02.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyValueController : ControllerBase
    {
               
        public PropertyValueController(ICalculatePropertyValue calculateAreaValue)
        {
            this.calculateAreaValue = calculateAreaValue;
        }

        public readonly ICalculatePropertyValue calculateAreaValue;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="meter"></param>
        /// <returns></returns>

        [HttpGet("calculate")]
        public async Task<ActionResult<PropertyResult>> GetCalculatePropertyValueAsync([FromQuery] double meter)
        {
            if (meter >= 10 && meter <= 1000)
            {
                
                var result = await calculateAreaValue.CalculateAsync(meter);
                return Ok(result);
            }
            else
            {
                return BadRequest("Valor informado inválido! envie algo entre 10 e 1000");

            }


            
           

        }
    }
}
