using onlatn_tv_project.AllDTOs;
using onlatn_tv_project.Models;
using onlatn_tv_project.Repositories;

namespace onlatn_tv_project.Services
{
    public class ShowsBackService : IShowsBackService
    {
        private readonly IShowsBackTVRepository showsBackTVRepository;
        public ShowsBackService(IShowsBackTVRepository showsBackTVRepository)
        {
            this.showsBackTVRepository = showsBackTVRepository;
        }


        public object AddShow(ShowsBackRequestDTO show)
        {
           if (show == null)
            {
                throw new ArgumentNullException(nameof(show), "Show cannot be null");
            }
            if(string.IsNullOrWhiteSpace(show.HeaderContentUz) || string.IsNullOrWhiteSpace(show.HeaderContentRu) || string.IsNullOrWhiteSpace(show.HeaderContentEn))
            {
                throw new ArgumentException("HeaderContent fields cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(show.MediumContentUz) || string.IsNullOrWhiteSpace(show.MediumContentRu) || string.IsNullOrWhiteSpace(show.MediumContentEn))
            {
                throw new ArgumentException("MediumContent fields cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(show.FooterContentUz) || string.IsNullOrWhiteSpace(show.FooterContentRu) || string.IsNullOrWhiteSpace(show.FooterContentEn))
            {
                throw new ArgumentException("FooterContent fields cannot be empty");
            }

            ShowsBackTV showEntity = new Models.ShowsBackTV
            {
                HeaderContentUz = show.HeaderContentUz,
                HeaderContentRu = show.HeaderContentRu,
                HeaderContentEn = show.HeaderContentEn,
                MediumContentUz = show.MediumContentUz,
                MediumContentRu = show.MediumContentRu,
                MediumContentEn = show.MediumContentEn,
                FooterContentUz = show.FooterContentUz,
                FooterContentRu = show.FooterContentRu,
                FooterContentEn = show.FooterContentEn,
                PublishedAt = DateTime.UtcNow
            };
            var addedShow = showsBackTVRepository.AddShowsBackTV(showEntity);

            return new ApiResponse<Models.ShowsBackTV>
            {
                Success = true,
                Message = "Show added successfully",
                Data = addedShow
            };
            
        }

        public object DeleteShow(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid show ID");
            }
                 showsBackTVRepository.DeleteShowsBackTV(id);
            return new ApiResponse<string>
            {
                Success = true,
                Message = "Show deleted successfully",
                Data = null
            };
           
        }

        public object GetAllShows()
        {
            var shows = showsBackTVRepository.GetShowsBackTVAll();
            return new ApiResponse<List<Models.ShowsBackTV>>
            {
                Success = true,
                Message = "Shows retrieved successfully",
                Data = shows
            };
        }

        public object GetShowById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid show ID");
            }
            var show = showsBackTVRepository.GetShowsBackTVById(id);
            return new ApiResponse<Models.ShowsBackTV>
            {
                Success = true,
                Message = "Show retrieved successfully",
                Data = show
            };
        }

        public object UpdateShow(int id, ShowsBackRequestDTO show)
        {
            if (id <= 0)
            {
               throw new ArgumentException("Invalid show ID");
            }
            if (show == null)
            {
                throw new ArgumentNullException(nameof(show), "Show cannot be null");
            }
             var existingShow = showsBackTVRepository.GetShowsBackTVById(id);
            if (existingShow == null)
            {
                throw new KeyNotFoundException("Show not found");
            }
            existingShow.HeaderContentUz = show.HeaderContentUz;
            existingShow.HeaderContentRu = show.HeaderContentRu;
            existingShow.HeaderContentEn = show.HeaderContentEn;
            existingShow.MediumContentUz = show.MediumContentUz;
            existingShow.MediumContentRu = show.MediumContentRu;
            existingShow.MediumContentEn = show.MediumContentEn;
            existingShow.FooterContentUz = show.FooterContentUz;
            existingShow.FooterContentRu = show.FooterContentRu;
            existingShow.FooterContentEn = show.FooterContentEn;
            var updatedShow = showsBackTVRepository.EditShowsBackTV(existingShow);

            return new ApiResponse<Models.ShowsBackTV>
            {
                Success = true,
                Message = "Show updated successfully",
                Data = updatedShow
            };
            
        }
    }
}
