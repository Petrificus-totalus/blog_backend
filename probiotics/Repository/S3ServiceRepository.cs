using Amazon.S3;
using Amazon.S3.Model;
using probiotics.Interfaces;

namespace probiotics.Repository;

public class S3ServiceRepository: IS3ServiceRepository
{
    private readonly AmazonS3Client _s3Client;
    private readonly string _bucketName = "myblogprobiotics";

    public S3ServiceRepository(IConfiguration configuration)
    {
        _s3Client = new AmazonS3Client(configuration["AWS:AccessKey"], configuration["AWS:SecretKey"], Amazon.RegionEndpoint.USEast1);
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        var key = $"transactions/{Guid.NewGuid()}_{file.FileName}";

        using var stream = file.OpenReadStream();
        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = key,
            InputStream = stream,
            ContentType = file.ContentType
        };

        await _s3Client.PutObjectAsync(request);

        return $"{key}";
    }
}