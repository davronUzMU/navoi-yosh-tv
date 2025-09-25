
namespace onlatn_tv_project.Services
{
    public interface IImageService
    {
        Task<Object> UploadImage(IFormFile file);
        Task<bool> DeleteById(int Id);
        Task<IEnumerable<Object>> GetAll();
        Task<string?> GetImageById(int Id);
    }
}
