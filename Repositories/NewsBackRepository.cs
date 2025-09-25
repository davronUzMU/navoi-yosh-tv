using onlatn_tv_project.Data;
using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public class NewsBackRepository : INewsBackRepository
    {
        private readonly AppDbContext _context;
        public NewsBackRepository(AppDbContext context)
        {
            _context = context;
        }

        public NewsBackTV AddNewsBackTV(NewsBackTV data)
        {
            _context.newsBackTVs.Add(data);
            _context.SaveChanges();
            return data;
        }

        public void DeleteNewsBackTV(int id)
        {
           if (_context.newsBackTVs.Find(id) is NewsBackTV newsBackTV)
            {
                _context.newsBackTVs.Remove(newsBackTV);
                _context.SaveChanges();
            }
        }

        public NewsBackTV EditNewsBackTV(NewsBackTV data)
        {
            _context.newsBackTVs.Update(data);
            _context.SaveChanges();
            return data;
            
        }

        public List<NewsBackTV> GetNewsBackTVAll()
        {
            return _context.newsBackTVs.ToList();
        }

        public NewsBackTV GetNewsBackTVById(int id)
        {
            return _context.newsBackTVs.Find(id);
        }
    }
}
