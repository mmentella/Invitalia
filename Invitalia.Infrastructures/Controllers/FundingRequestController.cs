using Invitalia.Infrastructures.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Invitalia.Infrastructures.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class FundingRequestController
        : ControllerBase
    {

        private readonly ILogger<FundingRequestController> logger;
        private readonly IRepository<FundingRequest> repository;

        public FundingRequestController(IRepository<FundingRequest> repository, ILogger<FundingRequestController> logger)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<FundingRequest>> GetAll()
        {
            var model = await repository.GetAsync(rdf => true);
            return model;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<FundingRequest> GetById([FromRoute] string id)
        {
            var model = await repository.GetAsync(id);
            return model;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(FundingRequest model)
        {
            model = await repository.CreateAsync(model);
            return Created($"/{model.Id}", model);
        }
    }
}