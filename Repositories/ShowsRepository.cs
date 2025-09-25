using onlatn_tv_project.Data;
using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public class ShowsRepository :IShowsRepository
    {
        private readonly AppDbContext _context;
        public ShowsRepository(AppDbContext context)
        {
            _context = context;
        }

        public ShowsTV AddShowsTV(ShowsTV data)
        {
            _context.showsTVs.Add(data);
            _context.SaveChanges();
            return data;
        }

        public void DeleteShowsTV(int id)
        {
            if(_context.showsTVs.Find(id) is ShowsTV showsTV)
            {
                _context.showsTVs.Remove(showsTV);
                _context.SaveChanges();
            }
           
        }

        public ShowsTV EditShowsTV(ShowsTV data)
        {
            _context.showsTVs.Update(data);
            _context.SaveChanges();
            return data;
           
        }

        public List<ShowsTV> GetShowsTVAll()
        {
            return _context.showsTVs.ToList();
            
        }

        public ShowsTV GetShowsTVById(int id)
        {
            return _context.showsTVs.Find(id);
            
        }
    }
}
