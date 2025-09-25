using onlatn_tv_project.AllDTOs;

namespace onlatn_tv_project.Services
{
    public interface INewsBackService
    {
        object AddNews(NewsBackRequestDTO news);
        object DeleteNews(int id);
        object GetNewsAll();
        object GetNewsById(int id);
        object UpdateNews(int id, NewsBackRequestDTO news);
    }
}
