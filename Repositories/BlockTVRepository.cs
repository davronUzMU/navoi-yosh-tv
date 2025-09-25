using onlatn_tv_project.Data;
using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public class BlockTVRepository : IBlockTVRepository
    {
        private readonly AppDbContext _context;

        public BlockTVRepository(AppDbContext context)
        {
            _context = context;
        }
        public BlockTV AddBlockTV(BlockTV data)
        {
            _context.blockTVs.Add(data);
            _context.SaveChanges();
            return data;
           
        }

        public void DeleteBlockTV(int id)
        {
            if (_context.blockTVs.Find(id) is BlockTV blockTV)
            {
                _context.blockTVs.Remove(blockTV);
                _context.SaveChanges();
            }
        }

        public BlockTV EditBlockTV(BlockTV data)
        {
            _context.blockTVs.Update(data);
            _context.SaveChanges();
            return data;
        }

        public List<BlockTV> GetBlockTVAll()
        {
            return _context.blockTVs.ToList();
        }

        public BlockTV GetBlockTVById(int id)
        {
            return _context.blockTVs.Find(id);
        }
    }
}
