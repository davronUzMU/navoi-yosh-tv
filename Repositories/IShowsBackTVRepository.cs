using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public interface IShowsBackTVRepository
    {
        List<ShowsBackTV> GetShowsBackTVAll();
        ShowsBackTV GetShowsBackTVById(int id);
        ShowsBackTV AddShowsBackTV(ShowsBackTV data);
        ShowsBackTV EditShowsBackTV(ShowsBackTV data);
        void DeleteShowsBackTV(int id);
    }
}
