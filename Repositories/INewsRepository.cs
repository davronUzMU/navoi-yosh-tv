using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public interface INewsRepository
    {
        List<NewsTV> GetNewTVAll();
        NewsTV GetNewById(int id);
        NewsTV AddNewTV(NewsTV data);
        NewsTV EditNewTV(NewsTV data);
        void DeleteBackTV(int id);
    }
}
