using Microsoft.AspNetCore.Mvc;
using SedolAPI.BusinessLogicLayer.Interfaces;
using System.Threading.Tasks;

namespace SedolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedolValidateController : ControllerBase
    {
        private readonly ISedolValidator _sedolValidator;

        public SedolValidateController(ISedolValidator sedolValidator)
        {
            _sedolValidator = sedolValidator;
        }

        [HttpGet]
        public async Task<ISedolValidationResult> Get(string input)
        {
            var response = _sedolValidator.ValidateSedol(input);

            return await Task.FromResult(response);
        }
    }
}