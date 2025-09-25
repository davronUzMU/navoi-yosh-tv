using onlatn_tv_project.Data;
using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public class TVProgramRepository :ITVProgramRepository
    {
        private readonly AppDbContext _context;
        public TVProgramRepository(AppDbContext context)
        {
            _context = context;
        }

        public TVProgram AddNewsBackTV(TVProgram data)
        {
            _context.tVPrograms.Add(data);
            _context.SaveChanges();
            return data; 
        }

        public void DeleteNewsBackTV(int id)
        {
            if(id <= 0) return;
            var existing = _context.tVPrograms.Find(id);
            if(existing == null) return;
            _context.tVPrograms.Remove(existing);
           
        }

        public TVProgram EditNewsBackTV(TVProgram data)
        {
            _context.tVPrograms.Update(data);
            _context.SaveChanges();
            return data;
            
        }

        public List<TVProgram> GetNewsBackTVAll()
        {
            return _context.tVPrograms.ToList();
        }

        public TVProgram GetNewsBackTVById(int id)
        {
            return _context.tVPrograms.Find(id);
        }
    }
}
