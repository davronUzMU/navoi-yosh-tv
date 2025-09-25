using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public interface IBlockTVRepository
    {
        List<BlockTV> GetBlockTVAll();
        BlockTV GetBlockTVById(int id);
        BlockTV AddBlockTV(BlockTV data);
        BlockTV EditBlockTV(BlockTV data);
        void DeleteBlockTV(int id);
    }
}
