using onlatn_tv_project.AllDTOs;
using onlatn_tv_project.Repositories;

namespace onlatn_tv_project.Services
{
    public class NewsBackService:INewsBackService
    {
        private readonly INewsBackRepository _newsBackRepository;
        public NewsBackService(INewsBackRepository newsBackRepository)
        {
            _newsBackRepository = newsBackRepository;
        }

        public object AddNews(NewsBackRequestDTO news)
        {
            if (news == null) { 
                throw new ArgumentNullException(nameof(news), "News cannot be null");
            }
            if (string.IsNullOrWhiteSpace(news.TitleUz) || string.IsNullOrWhiteSpace(news.TitleRu) || string.IsNullOrWhiteSpace(news.TitleEn))
            {
                throw new ArgumentException("Title fields cannot be empty");
            }
            if(string.IsNullOrWhiteSpace(news.HeaderContentUz) || string.IsNullOrWhiteSpace(news.HeaderContentRu) || string.IsNullOrWhiteSpace(news.HeaderContentEn))
            {
                throw new ArgumentException("HeaderContent fields cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(news.MainContentUz) || string.IsNullOrWhiteSpace(news.MainContentRu) || string.IsNullOrWhiteSpace(news.MainContentEn))
            {
                throw new ArgumentException("MainContent fields cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(news.FooterContentUz) || string.IsNullOrWhiteSpace(news.FooterContentRu) || string.IsNullOrWhiteSpace(news.FooterContentEn))
            {
                throw new ArgumentException("FooterContent fields cannot be empty");
            }

            var newsEntity = new Models.NewsBackTV
            {
                TitleUz = news.TitleUz,
                TitleRu = news.TitleRu,
                TitleEn = news.TitleEn,
                HeaderContentUz = news.HeaderContentUz,
                HeaderContentRu = news.HeaderContentRu,
                HeaderContentEn = news.HeaderContentEn,
                MainContentUz = news.MainContentUz,
                MainContentRu = news.MainContentRu,
                MainContentEn = news.MainContentEn,
                FooterContentUz = news.FooterContentUz,
                FooterContentRu = news.FooterContentRu,
                FooterContentEn = news.FooterContentEn,
                PublishedAt = DateTime.UtcNow
            };
            var addedNews = _newsBackRepository.AddNewsBackTV(newsEntity);
            return new ApiResponse<Models.NewsBackTV>
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
            _newsBackRepository.DeleteNewsBackTV(id);
            return new ApiResponse<string>
            {
                Success = true,
                Message = "News deleted successfully",
                Data = null
            };
        }

        public object GetNewsAll()
        {
            var newsList = _newsBackRepository.GetNewsBackTVAll();
            return new ApiResponse<List<Models.NewsBackTV>>
            {
                Success = true,
                Message = "News retrieved successfully",
                Data = newsList
            };
        }

        public object GetNewsById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid news ID");
            }
            var news = _newsBackRepository.GetNewsBackTVById(id);
            return new ApiResponse<Models.NewsBackTV>
            {
                Success = true,
                Message = "News retrieved successfully",
                Data = news
            };
        }

        public object UpdateNews(int id, NewsBackRequestDTO news)
        {
            if (news == null)
            {
                 throw new ArgumentNullException(nameof(news), "News cannot be null");
            }
            if (id <= 0)
            {
                throw new ArgumentException("Invalid news ID");
            }
            var existingNews = _newsBackRepository.GetNewsBackTVById(id);
            if (existingNews == null)
            {
                throw new KeyNotFoundException("News not found");
            }
            existingNews.TitleUz = news.TitleUz;
            existingNews.TitleRu = news.TitleRu;
            existingNews.TitleEn = news.TitleEn;
            existingNews.HeaderContentUz = news.HeaderContentUz;
            existingNews.HeaderContentRu = news.HeaderContentRu;
            existingNews.HeaderContentEn = news.HeaderContentEn;
            existingNews.MainContentUz = news.MainContentUz;
            existingNews.MainContentRu = news.MainContentRu;
            existingNews.MainContentEn = news.MainContentEn;
            existingNews.FooterContentUz = news.FooterContentUz;
            existingNews.FooterContentRu = news.FooterContentRu;
            existingNews.FooterContentEn = news.FooterContentEn;

            var updatedNews = _newsBackRepository.EditNewsBackTV(existingNews);
            return new ApiResponse<Models.NewsBackTV>
            {
                Success = true,
                Message = "News updated successfully",
                Data = updatedNews
            };
        }
    }
}
