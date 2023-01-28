using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TechExam_Morgan.Controllers
{
    [Route("/")]
    [ApiController]
    public class CovidController : Controller
    {
        private readonly ICovidObervationsService _obervationsService;

        public CovidController(ICovidObervationsService obervationsService)
        {
            _obervationsService = obervationsService;
        }

        [HttpGet("top/confirmed/")]
        public async Task<ActionResult<IEnumerable<CovidObservationsDTO>>> Get([Required] string observation_date, [Required] int max_results)
        {            
            return Ok(await _obervationsService.GetCovidList(DateOnly.Parse(observation_date), max_results));
        }
    }
}
