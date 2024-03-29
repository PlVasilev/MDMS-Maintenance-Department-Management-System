﻿using System.IO;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace MDMS.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinaryUtility;

        public CloudinaryService(Cloudinary cloudinaryUtility)
        {
            _cloudinaryUtility = cloudinaryUtility;
        }

        public async Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName)
        {
            byte[] destinationData;
            using (var ms = new MemoryStream())
            {
               await pictureFile.CopyToAsync(ms);
               destinationData = ms.ToArray();
            }

            UploadResult uploadResult = null;

            using (var ms = new MemoryStream(destinationData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams()
                {
                    Folder = "vehicle_images",
                    File = new FileDescription(fileName,ms)
                };
                uploadResult = _cloudinaryUtility.Upload(uploadParams);
            }

            return uploadResult?.SecureUri.AbsoluteUri;
        }
    }
}
