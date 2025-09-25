using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlatn_tv_project.AllDTOs;
using onlatn_tv_project.Services;

namespace onlatn_tv_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockBackController : ControllerBase
    {
        private readonly IBlockBackService _blockBackService;
        public BlockBackController(IBlockBackService blockBackService)
        {
            _blockBackService = blockBackService;
        }

        [HttpGet]
        public IActionResult GetAllBlocks()
        {
            try
            {
                var result = _blockBackService.GetBlockServices();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetBlockBackById(int id)
        {
            try
            {
                var result = _blockBackService.GetBlockBackById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddBlockBack([FromBody] BlockBackRequestDTO blockBack)
        {
            try
            {
                var result = _blockBackService.AddBlockBack(blockBack);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateBlockBack(int id, [FromBody] BlockBackRequestDTO blockBack)
        {
            try
            {
                var result = _blockBackService.UpdateBlockBack(id, blockBack);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteBlockBack(int id)
        {
            try
            {
                var result = _blockBackService.DeleteBlockBack(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
