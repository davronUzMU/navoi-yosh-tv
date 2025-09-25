using onlatn_tv_project.AllDTOs;

namespace onlatn_tv_project.Services
{
    public interface ITVProgramService
    {
        object AddTVProgramm(TVProgrammRequestDTO tvProgramm);
        object DeleteTVProgramm(int id);
        object GetTVProgrammAll();
        object GetTVProgrammById(int id);
        object UpdateTVProgramm(int id, TVProgrammRequestDTO tvProgramm);
    }
}
