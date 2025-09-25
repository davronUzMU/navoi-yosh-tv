using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlatn_tv_project.Services;

namespace onlatn_tv_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsBackController : ControllerBase
    {
        private readonly IShowsBackService showsBackService;
        public ShowsBackController(IShowsBackService showsBackService)
        {
            this.showsBackService = showsBackService;
        }
        [HttpGet]
        public IActionResult GetAllShows()
        {
            try
            {
                var result = showsBackService.GetAllShows();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetShowById(int id)
        {
            try
            {
                var result = showsBackService.GetShowById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddShow([FromBody] onlatn_tv_project.AllDTOs.ShowsBackRequestDTO show)
        {
            try
            {
                var result = showsBackService.AddShow(show);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateShow(int id, [FromBody] onlatn_tv_project.AllDTOs.ShowsBackRequestDTO show)
        {
            try
            {
                var result = showsBackService.UpdateShow(id, show);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteShow(int id)
        {
            try
            {
                var result = showsBackService.DeleteShow(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
