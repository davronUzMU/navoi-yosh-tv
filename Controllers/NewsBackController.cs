using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlatn_tv_project.AllDTOs;
using onlatn_tv_project.Models;
using onlatn_tv_project.Services;

namespace onlatn_tv_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsBackController : ControllerBase
    {
        private readonly INewsBackService _newsBackService;
        public NewsBackController(INewsBackService newsBackService)
        {
            _newsBackService = newsBackService;
        }
        [HttpGet]
        public IActionResult GetNewsAll()
        {
           try
            {
                var result = _newsBackService.GetNewsAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddNews([FromBody] NewsBackRequestDTO news)
        {
            try
            {
                var result = _newsBackService.AddNews(news);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetNewsById(int id)
        {
            try
            {
                var result = _newsBackService.GetNewsById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateNews(int id, [FromBody] NewsBackRequestDTO news)
        {
            try
            {
                var result = _newsBackService.UpdateNews(id, news);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteNews(int id)
        {
            try
            {
                var result = _newsBackService.DeleteNews(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
