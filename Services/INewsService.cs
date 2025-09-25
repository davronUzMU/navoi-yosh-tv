using onlatn_tv_project.AllDTOs;

namespace onlatn_tv_project.Services
{
    public interface INewsService
    {
        object AddNews(NewsRequestDTO news);
        object DeleteNews(int id);
        object GetNewsAll();
        object GetNewsById(int id);
        object UpdateNews(int id, NewsRequestDTO news);
    }
}
