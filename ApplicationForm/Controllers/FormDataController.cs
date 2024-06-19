using ApplicationForm.Models;
using ApplicationForm.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormDataController : ControllerBase
    {
        private readonly CosmosDbService _cosmosDbService;

        public FormDataController(CosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormData formData)
        {
            if (formData == null)
            {
                return BadRequest();
            }

            await _cosmosDbService.AddFormDataAsync(formData);
            return Ok();
        }

       
    }
}

