using DTOS;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelatedDataApi.Services;
using RelatedDataApi.Services.DataService;

namespace RelatedDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataServices _dataServices;

        public DataController(IDataServices dataServices)
        {
            _dataServices = dataServices;   
        }

        [HttpGet("getComics")]

        public async Task<ActionResult<ServiceResponse<List<ComicDTO>>>> getComics()
        {
            return Ok(await _dataServices.getComics());
        }
    }
}
