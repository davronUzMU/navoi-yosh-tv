using onlatn_tv_project.AllDTOs;
using onlatn_tv_project.Models;
using onlatn_tv_project.Repositories;

namespace onlatn_tv_project.Services
{
    public class NewsService :INewsService
    {
       private readonly INewsRepository _newsService;
        public NewsService(INewsRepository newsService)
        {
            _newsService = newsService;
        }

        public object AddNews(NewsRequestDTO news)
        {
            if (news == null)
            {
                throw new ArgumentNullException(nameof(news), "News cannot be null");
            }
            if(string.IsNullOrWhiteSpace(news.titleUz) || string.IsNullOrWhiteSpace(news.titleRu) || string.IsNullOrWhiteSpace(news.titleEn))
            {
                throw new ArgumentException("Title fields cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(news.contentUz) || string.IsNullOrWhiteSpace(news.contentRu) || string.IsNullOrWhiteSpace(news.contentEn))
            {
                throw new ArgumentException("Content fields cannot be empty");
            }
            var newsEntity = new Models.NewsTV
            {
                titleUz = news.titleUz,
                titleRu = news.titleRu,
                titleEn = news.titleEn,
                contentUz = news.contentUz,
                contentRu = news.contentRu,
                contentEn = news.contentEn,
                NewsImageId = news.NewsImageId,
                NewsBackTVId = news.NewsBackTVId,
                publishedAt = DateTime.UtcNow
            };  
            var addedNews = _newsService.AddNewTV(newsEntity);
            return new ApiResponse<Object>
            {
                Success = true,
                Message = "News added successfully",
                Data = addedNews
            };
        }

        public object DeleteNews(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid news ID");
            }
             _newsService.DeleteBackTV(id);
            return new ApiResponse<string>
            {
                Success = true,
                Message = "News deleted successfully",
                Data = null
            };
        }

        public object GetNewsAll()
        {
            var news= _newsService.GetNewTVAll();
            return new ApiResponse<Object>
            {
                Success = true,
                Message = "News retrieved successfully",
                Data = news
            };
        }

        public object GetNewsById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid news ID");
            }
            var news = _newsService.GetNewById(id);
            return new ApiResponse<Object>
            {
                Success = true,
                Message = "News retrieved successfully",
                Data = news
            };
        }

        public object UpdateNews(int id, NewsRequestDTO news)
        {
           if(id <= 0)
            {
                throw new ArgumentException("Invalid news ID");
            }
            if (news == null)
            {
                throw new ArgumentNullException(nameof(news), "News cannot be null");
            }
            var updatedNews=_newsService.GetNewById(id);
            if (updatedNews == null)
            {
                throw new KeyNotFoundException("News not found");
            }
            updatedNews.titleUz = news.titleUz;
            updatedNews.titleRu = news.titleRu;
            updatedNews.titleEn = news.titleEn;
            updatedNews.contentUz = news.contentUz;
            updatedNews.contentRu = news.contentRu;
            updatedNews.contentEn = news.contentEn;
            updatedNews.NewsImageId = news.NewsImageId;
            updatedNews.NewsBackTVId = news.NewsBackTVId;
            updatedNews.publishedAt = DateTime.UtcNow;

            _newsService.EditNewTV(updatedNews);

            //var updatedNews = _newsService.UpdateNews(id, news);

            return new ApiResponse<Object>
            {
                Success = true,
                Message = "News updated successfully",
                Data = updatedNews
            };
        }
    }
}
