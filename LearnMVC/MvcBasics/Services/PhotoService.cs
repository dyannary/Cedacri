﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using MvcBasics.Helpers;
using MvcBasics.Interfaces;

namespace MvcBasics.Services;

public class PhotoService : IPhotoService
{
    private readonly Cloudinary _cloudinary;
    public PhotoService(IOptions<CloudinarySettings> config)
    {
        var acc = new Account(
            config.Value.CloudName,
            config.Value.ApiKey,
            config.Value.ApiSecret
            );
        _cloudinary = new Cloudinary(acc);
    }
    public Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
    {
        //var uploadResult = new ImageUploadResult();
        //if(file.Length > 0)
        //{
        //    using var stream = file.OpenReadStream();  
        //    var uploadParams = new ImageUploadParams
        //    {
        //        File = new FileDescription(file.FileName, stream),
        //        Transformation = new Transformation()
        //                                .Height(500)
        //                                .Width(500)
        //                                .Crop("fill")
        //                                .Gravity("face")
        //    }
        //}
        throw new NotImplementedException();
    }

    public Task<DeletionResult> DeletePhotoAsync(string publicId)
    {
        throw new NotImplementedException();
    }
}
