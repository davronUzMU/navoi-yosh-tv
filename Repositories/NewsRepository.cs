using onlatn_tv_project.Data;
using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public class NewsRepository :INewsRepository
    {
        private readonly AppDbContext _context;
        public NewsRepository(AppDbContext context)
        {
            _context = context;
        }

        public NewsTV AddNewTV(NewsTV data)
        {
            _context.newsTVs.Add(data);
            _context.SaveChanges();
            return data;
        }

        public void DeleteBackTV(int id)
        {
            if(id <= 0) return;
            if(_context.newsTVs.Find(id) is not NewsTV existing)
                return;
            _context.newsTVs.Remove(existing);
            _context.SaveChanges();
           
        }

        public NewsTV EditNewTV(NewsTV data)
        {
            _context.newsTVs.Update(data);
            _context.SaveChanges();
            return data;
        }

        public NewsTV GetNewById(int id)
        {
            return _context.newsTVs.Find(id);
           
        }

        public List<NewsTV> GetNewTVAll()
        {
            return _context.newsTVs.ToList();
        }
    }
}
