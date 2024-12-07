namespace probiotics.Interfaces;

public interface IS3ServiceRepository
{
    public Task<string> UploadFileAsync(IFormFile file);
}