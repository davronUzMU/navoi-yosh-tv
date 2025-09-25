using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public interface IImageRepository
    {
        Task<Image> AddImageAsync(Image image);
        Task<IEnumerable<Image>> GetAllImageAsync();
        Task<Image?> GetImageByIdAsync(int id);
        Task<bool> DeleteImageAsync(int id);
    }
}
