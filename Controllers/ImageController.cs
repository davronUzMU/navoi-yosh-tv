using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlatn_tv_project.Services;

namespace onlatn_tv_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }


        [HttpPost("upload")]
        //[Authorize]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            try
            {
                var result = await _imageService.UploadImage(file);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllImages()
        {
            try
            {
                var images = await _imageService.GetAll();
                return Ok(images);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetImageById(int Id)
        {
            try
            {
                var imageUrl = await _imageService.GetImageById(Id);
                if (string.IsNullOrWhiteSpace(imageUrl))
                    return NotFound("Image not found");

                var uri = new Uri(imageUrl);
                var baseUrl = imageUrl.Split('?')[0]; // Toza URL (fayl nomigacha)
                var contentType = GetContentType(baseUrl); // Masalan, "image/png"

                using var httpClient = new HttpClient();
                var imageBytes = await httpClient.GetByteArrayAsync(imageUrl); // Rasmni yuklaymiz

                return File(imageBytes, contentType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteImage(int Id)
        {

            try
            {
                var result = await _imageService.DeleteById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private string GetContentType(string path)
        {
            var ext = Path.GetExtension(path).ToLower();
            return ext switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".svg" => "image/svg+xml",
                ".webp" => "image/webp",
                _ => "application/octet-stream"
            };
        }
    }
}
