using onlatn_tv_project.AllDTOs;
using onlatn_tv_project.Repositories;

namespace onlatn_tv_project.Services
{
    public class BlockService : IBlockService
    {
        private readonly IBlockTVRepository _blockTVRepository;
        public BlockService(IBlockTVRepository blockTVRepository)
        {
            _blockTVRepository = blockTVRepository;
        }

        public object AddBlockBack(BlockRequestDTO blockBack)
        {
            if(blockBack == null)
            {
                throw new ArgumentNullException(nameof(blockBack), "BlockBack cannot be null");
            }
            if(string.IsNullOrWhiteSpace(blockBack.TitleUz) || string.IsNullOrWhiteSpace(blockBack.TitleRu) || string.IsNullOrWhiteSpace(blockBack.TitleEn))
            {
                throw new ArgumentException("Title fields cannot be empty");
            }
            if(blockBack.ImageId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(blockBack.ImageId), "ImageId must be a positive integer");
            }
            if(blockBack.BlockBackTVId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(blockBack.BlockBackTVId), "BlockBackTVId must be a positive integer");
            }
            if(string.IsNullOrWhiteSpace(blockBack.DescriptionUz) || string.IsNullOrWhiteSpace(blockBack.DescriptionRu) || string.IsNullOrWhiteSpace(blockBack.DescriptionEn))
            {
                throw new ArgumentException("Description fields cannot be empty");
            }

            var blockTV = new Models.BlockTV
            {
                TitleUz = blockBack.TitleUz,
                TitleRu = blockBack.TitleRu,
                TitleEn = blockBack.TitleEn,
                ImageId = blockBack.ImageId,
                BlockBackTVId = blockBack.BlockBackTVId,
                DescriptionUz = blockBack.DescriptionUz,
                DescriptionRu = blockBack.DescriptionRu,
                DescriptionEn = blockBack.DescriptionEn
            };
            var addedBlockTV = _blockTVRepository.AddBlockTV(blockTV);
            return new ApiResponse<Models.BlockTV>
            {
                Success = true,
                Message = "BlockTV added successfully",
                Data = addedBlockTV
            };

           
        }

        public object DeleteBlockBack(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be a positive integer");
            }
            var existingBlockTV = _blockTVRepository.GetBlockTVById(id);
            if (existingBlockTV == null)
            {
                throw new KeyNotFoundException($"BlockTV with Id {id} not found");
            }
            _blockTVRepository.DeleteBlockTV(id);

            return new ApiResponse<string>
            {
                Success = true,
                Message = "BlockTV deleted successfully",
                Data = null
            };
        }

        public object GetBlockBackById(int id)
        {
            if (id <= 0)
            {
               throw new ArgumentOutOfRangeException(nameof(id), "Id must be a positive integer");
            }
            var blockTV = _blockTVRepository.GetBlockTVById(id);

            if (blockTV == null)
            {
                throw new KeyNotFoundException($"BlockTV with Id {id} not found");
            }
            return new ApiResponse<Models.BlockTV>
            {
                Success = true,
                Message = "BlockTV retrieved successfully",
                Data = blockTV
            };
        }

        public object GetBlockServices()
        {
            return new ApiResponse<IEnumerable<Models.BlockTV>>
            {
                Success = true,
                Message = "BlockTVs retrieved successfully",
                Data = _blockTVRepository.GetBlockTVAll()
            };
            
        }

        public object UpdateBlockBack(int id, BlockRequestDTO blockBack)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be a positive integer");
            }
            if (blockBack == null)
            {
                throw new ArgumentNullException(nameof(blockBack), "BlockBack cannot be null");
            }
            if (string.IsNullOrWhiteSpace(blockBack.TitleUz) || string.IsNullOrWhiteSpace(blockBack.TitleRu) || string.IsNullOrWhiteSpace(blockBack.TitleEn))
            {
                throw new ArgumentException("Title fields cannot be empty");
            }
            if (blockBack.ImageId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(blockBack.ImageId), "ImageId must be a positive integer");
            }
            if (blockBack.BlockBackTVId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(blockBack.BlockBackTVId), "BlockBackTVId must be a positive integer");
            }
            if (string.IsNullOrWhiteSpace(blockBack.DescriptionUz) || string.IsNullOrWhiteSpace(blockBack.DescriptionRu) || string.IsNullOrWhiteSpace(blockBack.DescriptionEn))
            {
                throw new ArgumentException("Description fields cannot be empty");
            }
            var existingBlockTV = _blockTVRepository.GetBlockTVById(id);
            if (existingBlockTV == null)
            {
                throw new KeyNotFoundException($"BlockTV with Id {id} not found");
            }
            existingBlockTV.TitleUz = blockBack.TitleUz;
            existingBlockTV.TitleRu = blockBack.TitleRu;
            existingBlockTV.TitleEn = blockBack.TitleEn;
            existingBlockTV.ImageId = blockBack.ImageId;
            existingBlockTV.BlockBackTVId = blockBack.BlockBackTVId;
            existingBlockTV.DescriptionUz = blockBack.DescriptionUz;
            existingBlockTV.DescriptionRu = blockBack.DescriptionRu;
            existingBlockTV.DescriptionEn = blockBack.DescriptionEn;

            var updatedBlockTV = _blockTVRepository.EditBlockTV(existingBlockTV);

            return new ApiResponse<Models.BlockTV>
            {
                Success = true,
                Message = "BlockTV updated successfully",
                Data = updatedBlockTV
            };
           
        }
    }
}
