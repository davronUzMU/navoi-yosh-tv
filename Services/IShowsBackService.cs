using onlatn_tv_project.AllDTOs;

namespace onlatn_tv_project.Services
{
    public interface IShowsBackService
    {
        object AddShow(ShowsBackRequestDTO show);
        object DeleteShow(int id);
        object GetAllShows();
        object GetShowById(int id);
        object UpdateShow(int id, ShowsBackRequestDTO show);
    }
}
