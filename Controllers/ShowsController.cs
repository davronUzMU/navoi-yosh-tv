using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlatn_tv_project.Services;

namespace onlatn_tv_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly IShowsService showsService;
        public ShowsController(IShowsService showsService)
        {
            this.showsService = showsService;
        }
        [HttpGet("/kinolar")]
        public IActionResult GetKinoAllShows()
        {
            try
            {
                var result = showsService.GetKinoAllShows();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/seriallar")]
        public IActionResult GetSerialAllShows()
        {
            try
            {
                var result = showsService.GetSerialAllShows();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/kongir-ochar-dasturlar")]
        public IActionResult GetAllShows()
        {
            try
            {
                var result = showsService.GetKODAllShows();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("kinolar/{id}")]
        public IActionResult GetKinoShowById(int id)
        {
            try
            {
                var result = showsService.GetKinoShowById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("seriallar/{id}")]
        public IActionResult GetSerialShowById(int id)
        {
            try
            {
                var result = showsService.GetSerialShowById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("kongir-ochar-dasturlar/{id}")]
        public IActionResult GetKODShowById(int id)
        {
            try
            {
                var result = showsService.GetKODShowById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("/admin/kinolar")]
        public IActionResult AddKinoShow([FromBody] onlatn_tv_project.AllDTOs.ShowsRequestDTO show)
        {
            try
            {
                var result = showsService.AddKinoShow(show);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("/admin/seriallar")]
        public IActionResult AddSerialShow([FromBody] onlatn_tv_project.AllDTOs.ShowsRequestDTO show)
        {
            try
            {
                var result = showsService.AddSerialShow(show);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("/admin/kongir-ochar-dasturlar")]
        public IActionResult AddKODShow([FromBody] onlatn_tv_project.AllDTOs.ShowsRequestDTO show)
        {
            try
            {
                var result = showsService.AddKODShow(show);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut("/admin/kinolar/{id}")]
        public IActionResult UpdateKinoShow(int id, [FromBody] onlatn_tv_project.AllDTOs.ShowsRequestDTO show)
        {
            try
            {
                var result = showsService.UpdateKinoShow(id, show);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut("/admin/seriallar/{id}")]
        public IActionResult UpdateSerialShow(int id, [FromBody] onlatn_tv_project.AllDTOs.ShowsRequestDTO show)
        {
            try
            {
                var result = showsService.UpdateSerialShow(id, show);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut("/admin/kongir-ochar-dasturlar/{id}")]
        public IActionResult UpdateKODShow(int id, [FromBody] onlatn_tv_project.AllDTOs.ShowsRequestDTO show)
        {
            try
            {
                var result = showsService.UpdateKODShow(id, show);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpDelete("/admin/kinolar/{id}")]
        public IActionResult DeleteKinoShow(int id)
        {
            try
            {
                var result = showsService.DeleteKinoShow(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpDelete("/admin/seriallar/{id}")]
        public IActionResult DeleteSerialShow(int id)
        {
            try
            {
                var result = showsService.DeleteSerialShow(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpDelete("/admin/kongir-ochar-dasturlar/{id}")]
        public IActionResult DeleteKODShow(int id)
        {
            try
            {
                var result = showsService.DeleteKODShow(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
