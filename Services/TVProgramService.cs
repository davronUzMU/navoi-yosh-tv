using onlatn_tv_project.AllDTOs;
using onlatn_tv_project.Repositories;

namespace onlatn_tv_project.Services
{
    public class TVProgramService : ITVProgramService
    {
        private readonly ITVProgramRepository _tvProgramRepository;
        public TVProgramService(ITVProgramRepository tvProgramRepository)
        {
            _tvProgramRepository = tvProgramRepository;
        }

        public object AddTVProgramm(TVProgrammRequestDTO tvProgramm)
        {
            if(tvProgramm == null)
            {
                throw new ArgumentNullException(nameof(tvProgramm), "TV Programm cannot be null");
            }
            if(string.IsNullOrWhiteSpace(tvProgramm.programNameUz) || string.IsNullOrWhiteSpace(tvProgramm.programNameRu) || string.IsNullOrWhiteSpace(tvProgramm.programNameEn))
            {
                throw new ArgumentException("ProgramName fields cannot be empty");
            }
            if(tvProgramm.dayOfWeekUz == null || tvProgramm.dayOfWeekRu == null || tvProgramm.dayOfWeekEn == null)
            {
                throw new ArgumentException("DayOfWeek fields cannot be null");
            }
            
            var tvProgramEntity = new Models.TVProgram
            {
                programNameUz = tvProgramm.programNameUz,
                programNameRu = tvProgramm.programNameRu,
                programNameEn = tvProgramm.programNameEn,
                dayOfWeekUz = tvProgramm.dayOfWeekUz,
                dayOfWeekRu = tvProgramm.dayOfWeekRu,
                dayOfWeekEn = tvProgramm.dayOfWeekEn,
                startTime = tvProgramm.startTime,
                endTime = tvProgramm.endTime
            };
            var addedTVProgram = _tvProgramRepository.AddNewsBackTV(tvProgramEntity);
            return new ApiResponse<Models.TVProgram>
            {
                Success = true,
                Message = "TV Program added successfully",
                Data = addedTVProgram
            };
        }

        public object DeleteTVProgramm(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
             _tvProgramRepository.DeleteNewsBackTV(id);
            return new ApiResponse<string>
            {
                Success = true,
                Message = "TV Program deleted successfully",
                Data = null
            };
           
        }

        public object GetTVProgrammAll()
        {
            var tvPrograms = _tvProgramRepository.GetNewsBackTVAll();

            return new ApiResponse<List<Models.TVProgram>>
            {
                Success = true,
                Message = "TV Programs retrieved successfully",
                Data = tvPrograms
            };
           
        }

        public object GetTVProgrammById(int id)
        {
            if (id <= 0) {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
            var tvProgram = _tvProgramRepository.GetNewsBackTVById(id);
            return new ApiResponse<Models.TVProgram>
            {
                Success = true,
                Message = "TV Program retrieved successfully",
                Data = tvProgram
            };
           
        }

        public object UpdateTVProgramm(int id, TVProgrammRequestDTO tvProgramm)
        {
            if (id <= 0) {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer");
            }
            if(tvProgramm == null)
            {
                throw new ArgumentNullException(nameof(tvProgramm), "TV Programm cannot be null");
            }
            var existingTVProgram = _tvProgramRepository.GetNewsBackTVById(id);
            if (existingTVProgram == null) {
                throw new KeyNotFoundException($"TV Program with ID {id} not found");
            }
            existingTVProgram.programNameUz = tvProgramm.programNameUz;
            existingTVProgram.programNameRu = tvProgramm.programNameRu;
            existingTVProgram.programNameEn = tvProgramm.programNameEn;
            existingTVProgram.dayOfWeekUz = tvProgramm.dayOfWeekUz;
            existingTVProgram.dayOfWeekRu = tvProgramm.dayOfWeekRu;
            existingTVProgram.dayOfWeekEn = tvProgramm.dayOfWeekEn;
            existingTVProgram.startTime = tvProgramm.startTime;
            existingTVProgram.endTime = tvProgramm.endTime;

            var updatedTVProgram = _tvProgramRepository.EditNewsBackTV(existingTVProgram);

            return new ApiResponse<Models.TVProgram>
            {
                Success = true,
                Message = "TV Program updated successfully",
                Data = updatedTVProgram
            };
        }
    }
}
