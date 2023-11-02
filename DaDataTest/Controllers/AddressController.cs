using AutoMapper;
using DaDataTest.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace DaDataTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly DaDataClient httpClient;

        private readonly ILogger logger;

        private readonly IMapper mapper;
        public AddressController(DaDataClient client, ILogger<AddressController> logger, IMapper mapper)
        {
            this.httpClient = client;
            this.logger = logger;
            this.mapper = mapper; 
        }

        [HttpGet]
        public async Task<ActionResult<JsonNode>> AddressReader(string address)
        {
            var response = await httpClient.PostAddress(address);
            var json = JsonNode.Parse(response);
            

            if (json != null) {
                logger.LogInformation($"Successfully posted to {httpClient.Url}");
                return Ok(json);
            }

            logger.LogError($"Error occured with {address} request to {httpClient.Url}");
            return BadRequest(JsonNode.Parse("{ \"message\": \"BadRequest\" }"));
        }
    }
}
