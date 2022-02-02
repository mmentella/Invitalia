using Invitalia.Infrastructures.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Invitalia.Infrastructures.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class OperatingUnitController
        : ControllerBase
    {

        private readonly ILogger<FundingRequestController> logger;
        private readonly IRepository<FundingRequest> repository;

        public OperatingUnitController(IRepository<FundingRequest> repository, ILogger<FundingRequestController> logger)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<OperatingUnit>> GetAll()
        {
            var model = await repository.GetAsync(rdf => true);
            return model.SelectMany(r => r.OperatingUnits);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<OperatingUnit?> GetById([FromRoute] string id)
        {
            var model = await repository.GetAsync(id);
            return model.OperatingUnits.SingleOrDefault(u => u.Id == id);
        }
    }
}