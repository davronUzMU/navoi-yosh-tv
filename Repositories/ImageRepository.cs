using Microsoft.EntityFrameworkCore;
using onlatn_tv_project.Data;
using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public class ImageRepository : IImageRepository
    {

        private readonly AppDbContext _context;
        public ImageRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Image> AddImageAsync(Image image)
        {
            await _context.images.AddAsync(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<bool> DeleteImageAsync(int id)
        {
            var img = await _context.images.FindAsync(id);
            if (img == null) return false;
            _context.images.Remove(img);
            _context.SaveChanges();
            return true;
            
        }

        public async Task<IEnumerable<Image>> GetAllImageAsync()
        {
            return await _context.images.ToListAsync();
        }

        public Task<Image?> GetImageByIdAsync(int id)
        {
            return _context.images.FindAsync(id).AsTask();
            
        }
    }
}
