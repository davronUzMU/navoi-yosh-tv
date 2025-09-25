using onlatn_tv_project.Models;

namespace onlatn_tv_project.Repositories
{
    public interface INewsBackRepository
    {
        List<NewsBackTV> GetNewsBackTVAll();
        NewsBackTV GetNewsBackTVById(int id);
        NewsBackTV AddNewsBackTV(NewsBackTV data);
        NewsBackTV EditNewsBackTV(NewsBackTV data);
        void DeleteNewsBackTV(int id);
    }
}
