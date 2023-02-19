using MicroservicesSandbox.DataAccess.Abstract;
using MicroservicesSandbox.DataValidation.Abstract;
using MicroservicesSandbox.Enums;
using MicroservicesSandbox.Models.Inventorys;
using MicroservicesSandbox.Models.Inventorys.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MicroservicesSandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        IDataValidator<IInventoryItem> validator;
        IDataProvider<IInventoryItem> provider;

        public InventoryController(IDataValidator<IInventoryItem> validator, IDataProvider<IInventoryItem> provider)
        {
            this.validator = validator;
            this.provider = provider;
        }

        // GET: api/<InventoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InventoryController>
        [HttpPost]
        public IActionResult Post([FromBody] InventoryItem entity)
        {
            ValidationResponseType validationResponseType = validator.Validate(entity);
            
            if (validationResponseType == ValidationResponseType.DataMissing)
            {
                return BadRequest("The request message was incomplete.");
            }
            
            if (validationResponseType == ValidationResponseType.DataInvalid)
            {
                return BadRequest("The request message contained invalid data.");
            }

            IDataResponse<IInventoryItem> dataResponse = provider.Add(entity);

            if (dataResponse.Type == DataResponseType.Error)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Ok(dataResponse.Data);
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
