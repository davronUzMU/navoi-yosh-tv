using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public interface ITVProgramRepository
    {
        List<TVProgram> GetNewsBackTVAll();
        TVProgram GetNewsBackTVById(int id);
        TVProgram AddNewsBackTV(TVProgram data);
        TVProgram EditNewsBackTV(TVProgram data);
        void DeleteNewsBackTV(int id);
    }
}
