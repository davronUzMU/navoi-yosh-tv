using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlatn_tv_project.AllDTOs;
using onlatn_tv_project.Services;

namespace onlatn_tv_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly IBlockService _blockService;
        public BlockController(IBlockService blockService)
        {
            _blockService = blockService;
        }

        [HttpGet]
        public IActionResult GetAllBlocks()
        {
            try
            {
                var result = _blockService.GetBlockServices();
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
                var result = _blockService.GetBlockBackById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddBlockBack([FromBody] BlockRequestDTO blockBack)
        {
            try
            {
                var result = _blockService.AddBlockBack(blockBack);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateBlockBack(int id, [FromBody] BlockRequestDTO blockBack)
        {
            try
            {
                var result = _blockService.UpdateBlockBack(id, blockBack);
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
                var result = _blockService.DeleteBlockBack(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
