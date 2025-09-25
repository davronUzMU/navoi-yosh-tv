using onlatn_tv_project.AllDTOs;
using onlatn_tv_project.Repositories;

namespace onlatn_tv_project.Services
{
    public class BlockBackService :IBlockBackService
    {
        private readonly IBlockBackRepository _blockBackRepository;
        public BlockBackService(IBlockBackRepository blockBackRepository)
        {
            _blockBackRepository = blockBackRepository;
        }

        public object AddBlockBack(BlockBackRequestDTO blockBack)
        {
            if(blockBack == null)
            {
                throw new ArgumentNullException(nameof(blockBack), "BlockBack cannot be null");
            }
            if(string.IsNullOrWhiteSpace(blockBack.TitleUz) || string.IsNullOrWhiteSpace(blockBack.TitleRu) || string.IsNullOrWhiteSpace(blockBack.TitleEn))
            {
                throw new ArgumentException("Title fields cannot be empty");
            }
            if(string.IsNullOrWhiteSpace(blockBack.HeaderContentUz) || string.IsNullOrWhiteSpace(blockBack.HeaderContentRu) || string.IsNullOrWhiteSpace(blockBack.HeaderContentEn))
            {
                throw new ArgumentException("HeaderContent fields cannot be empty");
            }
            if(string.IsNullOrWhiteSpace(blockBack.MainContentUz) || string.IsNullOrWhiteSpace(blockBack.MainContentRu) || string.IsNullOrWhiteSpace(blockBack.MainContentEn))
            {
                throw new ArgumentException("MainContent fields cannot be empty");
            }
            if(string.IsNullOrWhiteSpace(blockBack.FooterContentUz) || string.IsNullOrWhiteSpace(blockBack.FooterContentRu) || string.IsNullOrWhiteSpace(blockBack.FooterContentEn))
            {
                throw new ArgumentException("FooterContent fields cannot be empty");
            }

            var blockBackEntity = new Models.BlockBlackTV
            {
                TitleUz = blockBack.TitleUz,
                TitleRu = blockBack.TitleRu,
                TitleEn = blockBack.TitleEn,
                HeaderContentUz = blockBack.HeaderContentUz,
                HeaderContentRu = blockBack.HeaderContentRu,
                HeaderContentEn = blockBack.HeaderContentEn,
                MainContentUz = blockBack.MainContentUz,
                MainContentRu = blockBack.MainContentRu,
                MainContentEn = blockBack.MainContentEn,
                FooterContentUz = blockBack.FooterContentUz,
                FooterContentRu = blockBack.FooterContentRu,
                FooterContentEn = blockBack.FooterContentEn
            };

            var addedBlockBack = _blockBackRepository.AddBlockBlackTV(blockBackEntity);

            return new ApiResponse<Models.BlockBlackTV>
            {
                Success = true,
                Message = "BlockBack added successfully",
                Data = addedBlockBack
            };
        }

        public object DeleteBlockBack(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be a positive integer");
            }
            _blockBackRepository.DeleteBlockBlackTV(id);
            return new ApiResponse<string>
            {
                Success = true,
                Message = "BlockBack deleted successfully",
                Data = null
            };
        
        }

        public object GetBlockBackById(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be a positive integer");
            }
            var blockBack = _blockBackRepository.GetBlockBlackTVById(id);
            if(blockBack == null)
            {
                throw new KeyNotFoundException($"BlockBack with Id {id} not found");
            }
            return new ApiResponse<Models.BlockBlackTV>
            {
                Success = true,
                Message = "BlockBack retrieved successfully",
                Data = blockBack
            };
            
        }

        public object GetBlockServices()
        {
            return new ApiResponse<List<Models.BlockBlackTV>>
            {
                Success = true,
                Message = "BlockBacks retrieved successfully",
                Data = _blockBackRepository.GetBlockBlackTVAll()
            };
        }

        public object UpdateBlockBack(int id, BlockBackRequestDTO blockBack)
        {
            if(id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be a positive integer");
            }
            if(blockBack == null)
            {
                throw new ArgumentNullException(nameof(blockBack), "BlockBack cannot be null");
            }
            var existingBlockBack = _blockBackRepository.GetBlockBlackTVById(id);
            if(existingBlockBack == null)
            {
                throw new KeyNotFoundException($"BlockBack with Id {id} not found");
            }

            existingBlockBack.TitleUz = blockBack.TitleUz;
            existingBlockBack.TitleRu = blockBack.TitleRu;
            existingBlockBack.TitleEn = blockBack.TitleEn;
            existingBlockBack.HeaderContentUz = blockBack.HeaderContentUz;
            existingBlockBack.HeaderContentRu = blockBack.HeaderContentRu;
            existingBlockBack.HeaderContentEn = blockBack.HeaderContentEn;
            existingBlockBack.MainContentUz = blockBack.MainContentUz;
            existingBlockBack.MainContentRu = blockBack.MainContentRu;
            existingBlockBack.MainContentEn = blockBack.MainContentEn;
            existingBlockBack.FooterContentUz = blockBack.FooterContentUz;
            existingBlockBack.FooterContentRu = blockBack.FooterContentRu;
            existingBlockBack.FooterContentEn = blockBack.FooterContentEn;

            var updatedBlockBack = _blockBackRepository.EditBlockBlackTV(existingBlockBack);

            return new ApiResponse<Models.BlockBlackTV>
            {
                Success = true,
                Message = "BlockBack updated successfully",
                Data = updatedBlockBack
            };
        }
    }
}
