using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public interface IBlockBackRepository
    {
        List<BlockBlackTV> GetBlockBlackTVAll();
        BlockBlackTV GetBlockBlackTVById(int id);
        BlockBlackTV AddBlockBlackTV(BlockBlackTV data);
        BlockBlackTV EditBlockBlackTV(BlockBlackTV data);
        void DeleteBlockBlackTV(int id);
    }
}
