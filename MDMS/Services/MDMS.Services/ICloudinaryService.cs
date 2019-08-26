using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MDMS.Services
{
    public interface ICloudinaryService
    {
        Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
    }
}
