using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using onlatn_tv_project.Models;
using onlatn_tv_project.Repositories;

namespace onlatn_tv_project.Services
{
    public class ImageService:IImageService
    {
        private readonly MinioClient _minioClient;

        private readonly IImageRepository _imageRepository;

        private readonly string _bucketName = "navoi-council";

        public ImageService(MinioClient minioClient, IImageRepository imageRepository)
        {
            _minioClient = minioClient;
            _imageRepository = imageRepository;
        }

        public async Task<bool> DeleteById(int Id)
        {
            var image = await _imageRepository.GetImageByIdAsync(Id);
            if (image == null)
            {
                return false;
            }

            try
            {
                await _minioClient.RemoveObjectAsync(new RemoveObjectArgs()
                    .WithBucket(_bucketName)
                    .WithObject(image.ImageName));
            }
            catch (MinioException e)
            {
                return false;
            }

            var result = await _imageRepository.DeleteImageAsync(Id);
            return result;
        }

        public async Task<IEnumerable<object>> GetAll()
        {
            var imageHospitals = await _imageRepository.GetAllImageAsync();
            var imageResponseDTOs = new List<Image>();

            foreach (var item in imageHospitals)
            {
                var presignedUrl = await _minioClient.PresignedGetObjectAsync(
                    new PresignedGetObjectArgs()
                        .WithBucket(_bucketName)
                        .WithObject(item.ImageName)
                        .WithExpiry(3600));

                imageResponseDTOs.Add(new Image
                {
                    Id = item.Id,
                    ImageName = item.ImageName,
                    ImagePath = presignedUrl,
                    CreateTime = item.CreateTime
                });
            }

            return imageResponseDTOs;
        }

        public async Task<string?> GetImageById(int Id)
        {
            var image = await _imageRepository.GetImageByIdAsync(Id);

            if (image == null)
            {
                return "Rasmlar mavjud emas!!!";
            }

            try
            {
                var url = await _minioClient.PresignedGetObjectAsync(
                    new PresignedGetObjectArgs()
                        .WithBucket(_bucketName)
                        .WithObject(image.ImageName)
                        .WithExpiry(3600));

                return url;
            }
            catch (MinioException e)
            {
                return null;
            }
        }

        public async Task<object> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Fayl bo'sh bo'lishi mumkin emas.");
            }

            var uniqueFileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{DateTime.Now.Ticks}{Path.GetExtension(file.FileName)}";

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            try
            {
                // Bucket mavjudligini tekshirish
                var bucketExists = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(_bucketName));
                if (!bucketExists)
                {
                    // Agar bucket mavjud bo'lmasa, uni yaratish
                    await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(_bucketName));
                }

                // Faylni MinIO'ga yuklash
                var putObjectArgs = new PutObjectArgs()
                    .WithBucket(_bucketName)
                    .WithObject(uniqueFileName)
                    .WithStreamData(memoryStream)
                    .WithObjectSize(memoryStream.Length)
                    .WithContentType(file.ContentType);
                await _minioClient.PutObjectAsync(putObjectArgs);

                var getPresignedUrl = await _minioClient.PresignedGetObjectAsync(
                                          new PresignedGetObjectArgs()
                                            .WithBucket(_bucketName)
                                            .WithObject(uniqueFileName)
                                            .WithExpiry(3600));
                var image = new Models.Image
                {
                    ImageName = uniqueFileName,
                    ImagePath = getPresignedUrl,
                    CreateTime = DateTime.UtcNow
                };
                var img2 = await _imageRepository.AddImageAsync(image);
                return new Image
                {
                    Id = img2.Id,
                    ImageName = img2.ImageName,
                    ImagePath = getPresignedUrl,
                    CreateTime = img2.CreateTime
                };

            }
            catch (MinioException e)
            {
                throw new InvalidOperationException("Faylni yuklashda xatolik yuz berdi.", e);
            }
        }
    }
}
