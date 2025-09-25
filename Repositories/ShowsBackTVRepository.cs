using onlatn_tv_project.Data;
using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public class ShowsBackTVRepository :IShowsBackTVRepository
    {
      private readonly AppDbContext _context;
        public ShowsBackTVRepository(AppDbContext context)
        {
            _context = context;
        }

        public ShowsBackTV AddShowsBackTV(ShowsBackTV data)
        {
            _context.showsBackTVs.Add(data);
            _context.SaveChanges();
            return data;
            
        }

        public void DeleteShowsBackTV(int id)
        {
            if(_context.showsBackTVs.Find(id) is ShowsBackTV showsBackTV)
            {
                _context.showsBackTVs.Remove(showsBackTV);
                _context.SaveChanges();
            }
           
        }

        public ShowsBackTV EditShowsBackTV(ShowsBackTV data)
        {
            _context.showsBackTVs.Update(data);
            _context.SaveChanges();
            return data;
          
        }

        public List<ShowsBackTV> GetShowsBackTVAll()
        {
           return _context.showsBackTVs.ToList();
           
        }

        public ShowsBackTV GetShowsBackTVById(int id)
        {
              return _context.showsBackTVs.Find(id);
        }
    }
}
