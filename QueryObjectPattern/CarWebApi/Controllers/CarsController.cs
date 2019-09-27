using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DataSources;
using Domain.Queries;

namespace CarWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IDbDataAccess _dbSource;
        private readonly IApiDataAccess _apiSource;

        public CarsController(IDbDataAccess dbSource, IApiDataAccess apiSource)
        {
            _dbSource = dbSource;
            _apiSource = apiSource;
        }

        [HttpGet("{regNo}")]
        public async Task<ActionResult<Domain.Models.Car>> Get(string regNo)
        {
            var query = new CarByRegNo(regNo);
            var car = await query.Execute(_dbSource);

            return Ok(car);
        }

        [HttpGet("{regNo}/taxrate")]
        public async Task<ActionResult<float>> GetTaxRate(string regNo)
        {
            var query = new TaxByRegNo(regNo);
            var rate = await query.Execute(_apiSource);

            return Ok(rate);
        }
    }
}
