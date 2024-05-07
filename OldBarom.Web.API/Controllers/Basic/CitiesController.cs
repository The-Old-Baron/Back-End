using Microsoft.AspNetCore.Mvc;
using OldBarom.Core.Domain.Entities.Basic;

namespace OldBarom.Web.API.Controllers.Basic{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase{
        private readonly ICitiesService _citiesService;
        public CitiesController(){

        }
        [HttpGet(Name = "GetCities")]
        public IEnumerable<string> Get(){
            return null;
        }
    }
}