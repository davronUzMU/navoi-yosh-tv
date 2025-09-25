using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public interface IShowsRepository
    {
        List<ShowsTV> GetShowsTVAll();
        ShowsTV GetShowsTVById(int id);
        ShowsTV AddShowsTV(ShowsTV data);
        ShowsTV EditShowsTV(ShowsTV data);
        void DeleteShowsTV(int id);
    }
}
