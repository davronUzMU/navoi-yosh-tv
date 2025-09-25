using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlatn_tv_project.Services;

namespace onlatn_tv_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TVProgrammController : ControllerBase
    {
        private readonly ITVProgramService _tvProgrammService;
        public TVProgrammController(ITVProgramService tvProgrammService)
        {
            _tvProgrammService = tvProgrammService;
        }
        [HttpGet]
        public IActionResult GetTVProgrammAll()
        {
           try
            {
                var result = _tvProgrammService.GetTVProgrammAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetTVProgrammById(int id)
        {
            try
            {
                var result = _tvProgrammService.GetTVProgrammById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddTVProgramm([FromBody] onlatn_tv_project.AllDTOs.TVProgrammRequestDTO tvProgramm)
        {
            try
            {
                var result = _tvProgrammService.AddTVProgramm(tvProgramm);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateTVProgramm(int id, [FromBody] onlatn_tv_project.AllDTOs.TVProgrammRequestDTO tvProgramm)
        {
            try
            {
                var result = _tvProgrammService.UpdateTVProgramm(id, tvProgramm);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteTVProgramm(int id)
        {
            try
            {
                var result = _tvProgrammService.DeleteTVProgramm(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
