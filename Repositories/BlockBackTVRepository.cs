using onlatn_tv_project.Data;
using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public class BlockBackTVRepository:IBlockBackRepository
    {
        private readonly AppDbContext _context;
        public BlockBackTVRepository(AppDbContext context)
        {
            _context = context;
        }

        public BlockBlackTV AddBlockBlackTV(BlockBlackTV data)
        {
            _context.blockBackTVs.Add(data);
            _context.SaveChanges();
            return data;
        }

        public void DeleteBlockBlackTV(int id)
        {
            if(_context.blockBackTVs.Find(id) is BlockBlackTV data)
            {
                _context.blockBackTVs.Remove(data);
                _context.SaveChanges();
            }
            
        }

        public BlockBlackTV EditBlockBlackTV(BlockBlackTV data)
        {
            _context.blockBackTVs.Update(data);
            _context.SaveChanges();
            return data;
        }

        public List<BlockBlackTV> GetBlockBlackTVAll()
        {
            return _context.blockBackTVs.ToList();
        }

        public BlockBlackTV GetBlockBlackTVById(int id)
        {
            return _context.blockBackTVs.Find(id);
        }
    }

    
}
