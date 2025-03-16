using Minio.DataModel.Args;
using Minio;
using Minio.ApiEndpoints;

namespace MinioWebApi.Services
{
    public class MinioService
    {
        private readonly IMinioClient _minioClient;
        private readonly string _bucketName;

        public MinioService(IConfiguration configuration)
        {
            _minioClient = new MinioClient()
                .WithEndpoint(configuration["Minio:Endpoint"])
                .WithCredentials(configuration["Minio:AccessKey"], configuration["Minio:SecretKey"])
                .WithSSL(false) // Set to true if using HTTPS
                .Build();

            _bucketName = configuration["Minio:BucketName"];
            EnsureBucketExists().Wait();
        }

        private async Task EnsureBucketExists()
        {
            try
            {
                var beArgs = new BucketExistsArgs().WithBucket(_bucketName);
                bool found = await _minioClient.BucketExistsAsync(beArgs);
                if (!found)
                {
                    var mbArgs = new MakeBucketArgs().WithBucket(_bucketName);
                    await _minioClient.MakeBucketAsync(mbArgs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking bucket: {ex.Message}");
            }
        }

        public async Task UploadFileAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var putObjectArgs = new PutObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(file.FileName)
                .WithStreamData(stream)
                .WithObjectSize(file.Length)
                .WithContentType(file.ContentType);

            await _minioClient.PutObjectAsync(putObjectArgs);
        }

        public async Task<List<string>> ListFilesAsync()
        {
            var files = new List<string>();

            var listObjectsArgs = new ListObjectsArgs()
                .WithBucket(_bucketName)
                .WithRecursive(true);


            //var listObject = _minioClient.ListObjectsAsync(listObjectsArgs);

            //await foreach (var obj in listObject)
            //{
            //    files.Add(obj.Key);
            //}

            return files;
        }

        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            var ms = new MemoryStream();

            var getObjectArgs = new GetObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(fileName)
                .WithCallbackStream(stream => stream.CopyTo(ms));

            await _minioClient.GetObjectAsync(getObjectArgs);
            ms.Position = 0;

            return ms;
        }
    }
}
