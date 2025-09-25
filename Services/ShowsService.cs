using onlatn_tv_project.AllDTOs;
using onlatn_tv_project.Repositories;

namespace onlatn_tv_project.Services
{
    public class ShowsService : IShowsService
    {
        private readonly IShowsRepository _showsRepository;
        public ShowsService(IShowsRepository showsRepository)
        {
            _showsRepository = showsRepository;
        }

        public object AddKinoShow(ShowsRequestDTO show)
        {
            if (show == null)
            {
                throw new ArgumentNullException(nameof(show), "Show cannot be null");
            }
            if(string.IsNullOrWhiteSpace(show.TitleUz) || string.IsNullOrWhiteSpace(show.TitleRu) || string.IsNullOrWhiteSpace(show.TitleEn))
            {
                throw new ArgumentException("Title fields cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(show.DescriptionUz) || string.IsNullOrWhiteSpace(show.DescriptionRu) || string.IsNullOrWhiteSpace(show.DescriptionEn))
            {
                throw new ArgumentException("Description fields cannot be empty");
            }

            var showEntity = new Models.ShowsTV
            {
                TypeTv="Kino",
                TitleUz = show.TitleUz,
                TitleRu = show.TitleRu,
                TitleEn = show.TitleEn,
                ImageId = show.ImageId,
                ShowsBackTVId = show.ShowsBackTVId,
                DescriptionUz = show.DescriptionUz,
                DescriptionRu = show.DescriptionRu,
                DescriptionEn = show.DescriptionEn,
                AiredDateAt= DateTime.UtcNow
            };
            _showsRepository.AddShowsTV(showEntity);

            return new ApiResponse<Models.ShowsTV>
            {
                Success = true,
                Message = "Show added successfully",
                Data = _showsRepository.AddShowsTV(showEntity)
            };
        }

        public object AddKODShow(ShowsRequestDTO show)
        {
            if (show == null)
            {
                throw new ArgumentNullException(nameof(show), "Show cannot be null");
            }
            if (string.IsNullOrWhiteSpace(show.TitleUz) || string.IsNullOrWhiteSpace(show.TitleRu) || string.IsNullOrWhiteSpace(show.TitleEn))
            {
                throw new ArgumentException("Title fields cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(show.DescriptionUz) || string.IsNullOrWhiteSpace(show.DescriptionRu) || string.IsNullOrWhiteSpace(show.DescriptionEn))
            {
                throw new ArgumentException("Description fields cannot be empty");
            }

            var showEntity = new Models.ShowsTV
            {
                TypeTv = "kongir-ochar-dasturlar",
                TitleUz = show.TitleUz,
                TitleRu = show.TitleRu,
                TitleEn = show.TitleEn,
                ImageId = show.ImageId,
                ShowsBackTVId = show.ShowsBackTVId,
                DescriptionUz = show.DescriptionUz,
                DescriptionRu = show.DescriptionRu,
                DescriptionEn = show.DescriptionEn,
                AiredDateAt = DateTime.UtcNow
            };
            _showsRepository.AddShowsTV(showEntity);

            return new ApiResponse<Models.ShowsTV>
            {
                Success = true,
                Message = "Show added successfully",
                Data = _showsRepository.AddShowsTV(showEntity)
            };
        }

        public object AddSerialShow(ShowsRequestDTO show)
        {
            if (show == null)
            {
                throw new ArgumentNullException(nameof(show), "Show cannot be null");
            }
            if (string.IsNullOrWhiteSpace(show.TitleUz) || string.IsNullOrWhiteSpace(show.TitleRu) || string.IsNullOrWhiteSpace(show.TitleEn))
            {
                throw new ArgumentException("Title fields cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(show.DescriptionUz) || string.IsNullOrWhiteSpace(show.DescriptionRu) || string.IsNullOrWhiteSpace(show.DescriptionEn))
            {
                throw new ArgumentException("Description fields cannot be empty");
            }

            var showEntity = new Models.ShowsTV
            {
                TypeTv = "Serial",
                TitleUz = show.TitleUz,
                TitleRu = show.TitleRu,
                TitleEn = show.TitleEn,
                ImageId = show.ImageId,
                ShowsBackTVId = show.ShowsBackTVId,
                DescriptionUz = show.DescriptionUz,
                DescriptionRu = show.DescriptionRu,
                DescriptionEn = show.DescriptionEn,
                AiredDateAt = DateTime.UtcNow
            };
            _showsRepository.AddShowsTV(showEntity);

            return new ApiResponse<Models.ShowsTV>
            {
                Success = true,
                Message = "Show added successfully",
                Data = _showsRepository.AddShowsTV(showEntity)
            };
        }

        public object DeleteKinoShow(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
            if(_showsRepository.GetShowsTVById(id) == null)
            {
                throw new KeyNotFoundException("Show with the specified ID does not exist");
            }
            _showsRepository.DeleteShowsTV(id);
            return new ApiResponse<string>
            {
                Success = true,
                Message = "Show deleted successfully",
                Data = null
            };
        }

        public object DeleteKODShow(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
            if (_showsRepository.GetShowsTVById(id) == null)
            {
                throw new KeyNotFoundException("Show with the specified ID does not exist");
            }
            _showsRepository.DeleteShowsTV(id);
            return new ApiResponse<string>
            {
                Success = true,
                Message = "Show deleted successfully",
                Data = null
            };
        }

        public object DeleteSerialShow(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
            if (_showsRepository.GetShowsTVById(id) == null)
            {
                throw new KeyNotFoundException("Show with the specified ID does not exist");
            }
            _showsRepository.DeleteShowsTV(id);
            return new ApiResponse<string>
            {
                Success = true,
                Message = "Show deleted successfully",
                Data = null
            };
        }

        public object GetKinoAllShows()
        {
            var shows = _showsRepository.GetShowsTVAll().Where(s => s.TypeTv == "Kino").ToList();
            return new ApiResponse<List<Models.ShowsTV>>
            {
                Success = true,
                Message = "Shows retrieved successfully",
                Data = shows
            };
        }

        public object GetKinoShowById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
            var show = _showsRepository.GetShowsTVById(id);

            return new ApiResponse<Models.ShowsTV>
            {
                Success = true,
                Message = "Show retrieved successfully",
                Data = show
            };
        }

        public object GetKODAllShows()
        {
            var shows = _showsRepository.GetShowsTVAll().Where(s => s.TypeTv == "kongir-ochar-dasturlar").ToList();
            return new ApiResponse<List<Models.ShowsTV>>
            {
                Success = true,
                Message = "Shows retrieved successfully",
                Data = shows
            };
        }

        public object GetKODShowById(int id)
        {
            if (id <= 0)
            {
                 throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
            var show = _showsRepository.GetShowsTVById(id);
            return new ApiResponse<Models.ShowsTV>
            {
                Success = true,
                Message = "Show retrieved successfully",
                Data = show
            };
        }

        public object GetSerialAllShows()
        {
            var shows = _showsRepository.GetShowsTVAll().Where(s => s.TypeTv == "Serial").ToList();
            return new ApiResponse<List<Models.ShowsTV>>
            {
                Success = true,
                Message = "Shows retrieved successfully",
                Data = shows
            };
        }

        public object GetSerialShowById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
            var show = _showsRepository.GetShowsTVById(id);
            return new ApiResponse<Models.ShowsTV>
            {
                Success = true,
                Message = "Show retrieved successfully",
                Data = show
            };
        }

        public object UpdateKinoShow(int id, ShowsRequestDTO show)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
            if (show == null)
            {
                throw new ArgumentNullException(nameof(show), "Show cannot be null");
            }
            var existingShow = _showsRepository.GetShowsTVById(id);
            if (existingShow == null)
            {
                throw new KeyNotFoundException("Show with the specified ID does not exist");
            }
            existingShow.TitleUz = show.TitleUz;
            existingShow.TitleRu = show.TitleRu;
            existingShow.TitleEn = show.TitleEn;
            existingShow.ImageId = show.ImageId;
            existingShow.ShowsBackTVId = show.ShowsBackTVId;
            existingShow.DescriptionUz = show.DescriptionUz;
            existingShow.DescriptionRu = show.DescriptionRu;
            existingShow.DescriptionEn = show.DescriptionEn;
            var updatedShow = _showsRepository.EditShowsTV(existingShow);
            return new ApiResponse<Models.ShowsTV>
            {
                Success = true,
                Message = "Show updated successfully",
                Data = updatedShow
            };
        }

        public object UpdateKODShow(int id, ShowsRequestDTO show)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
            if (show == null)
            {
                throw new ArgumentNullException(nameof(show), "Show cannot be null");
            }
            var existingShow = _showsRepository.GetShowsTVById(id);
            if (existingShow == null)
            {
                throw new KeyNotFoundException("Show with the specified ID does not exist");
            }
            existingShow.TitleUz = show.TitleUz;
            existingShow.TitleRu = show.TitleRu;
            existingShow.TitleEn = show.TitleEn;
            existingShow.ImageId = show.ImageId;
            existingShow.ShowsBackTVId = show.ShowsBackTVId;
            existingShow.DescriptionUz = show.DescriptionUz;
            existingShow.DescriptionRu = show.DescriptionRu;
            existingShow.DescriptionEn = show.DescriptionEn;
            var updatedShow = _showsRepository.EditShowsTV(existingShow);
            return new ApiResponse<Models.ShowsTV>
            {
                Success = true,
                Message = "Show updated successfully",
                Data = updatedShow
            };
        }

        public object UpdateSerialShow(int id, ShowsRequestDTO show)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
            if (show == null)
            {
                throw new ArgumentNullException(nameof(show), "Show cannot be null");
            }
            var existingShow = _showsRepository.GetShowsTVById(id);
            if (existingShow == null)
            {
                throw new KeyNotFoundException("Show with the specified ID does not exist");
            }
            existingShow.TitleUz = show.TitleUz;
            existingShow.TitleRu = show.TitleRu;
            existingShow.TitleEn = show.TitleEn;
            existingShow.ImageId = show.ImageId;
            existingShow.ShowsBackTVId = show.ShowsBackTVId;
            existingShow.DescriptionUz = show.DescriptionUz;
            existingShow.DescriptionRu = show.DescriptionRu;
            existingShow.DescriptionEn = show.DescriptionEn;
            var updatedShow = _showsRepository.EditShowsTV(existingShow);
            return new ApiResponse<Models.ShowsTV>
            {
                Success = true,
                Message = "Show updated successfully",
                Data = updatedShow
            };
        }
    }
}
