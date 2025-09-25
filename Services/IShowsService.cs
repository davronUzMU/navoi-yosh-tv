using onlatn_tv_project.AllDTOs;

namespace onlatn_tv_project.Services
{
    public interface IShowsService
    {
        object AddKinoShow(ShowsRequestDTO show);
        object AddKODShow(ShowsRequestDTO show);
        object AddSerialShow(ShowsRequestDTO show);
        object DeleteKinoShow(int id);
        object DeleteKODShow(int id);
        object DeleteSerialShow(int id);
        object GetKinoAllShows();
        object GetKinoShowById(int id);
        object GetKODAllShows();
        object GetKODShowById(int id);
        object GetSerialAllShows();
        object GetSerialShowById(int id);
        object UpdateKinoShow(int id, ShowsRequestDTO show);
        object UpdateKODShow(int id, ShowsRequestDTO show);
        object UpdateSerialShow(int id, ShowsRequestDTO show);
    }
}
