using onlatn_tv_project.AllDTOs;

namespace onlatn_tv_project.Services
{
    public interface IBlockBackService
    {
        object AddBlockBack(BlockBackRequestDTO blockBack);
        object DeleteBlockBack(int id);
        object GetBlockBackById(int id);
        object GetBlockServices();
        object UpdateBlockBack(int id, BlockBackRequestDTO blockBack);
    }
}
