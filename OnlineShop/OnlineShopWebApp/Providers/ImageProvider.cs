using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using OnlineShop.DB;

namespace OnlineShopWebApp.Providers
{
    public class ImageProvider
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public ImageProvider(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public List<ImageViewModel> AddProductImages(ItemViewModel item, string imageProductsFolder)
        {
            var imagesViewModel = new List<ImageViewModel>();
            if (item.UploadedFiles != null)
            {
                foreach (var file in item.UploadedFiles)
                {
                    var productImagePath = Path.Combine(_appEnvironment.WebRootPath + imageProductsFolder);
                    if (!Directory.Exists(productImagePath))
                    {
                        Directory.CreateDirectory(productImagePath);
                    }

                    var imageFileName = Guid.NewGuid() + "." + Path.GetFileName(file.FileName).Split('.').Last();
                    using (var fileStream = new FileStream(Path.Combine(productImagePath, imageFileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    imagesViewModel.Add(new ImageViewModel() { URL = Path.Combine(imageProductsFolder, imageFileName) });
                }
            }
            return imagesViewModel;
        }

        public string AddAvatarImage(ProfileViewModel profileViewModel)
        {
            var avatarUserPath = Path.Combine(_appEnvironment.WebRootPath + Constants.AvatarFolder);
            if (!Directory.Exists(avatarUserPath))
                Directory.CreateDirectory(avatarUserPath);

            var avatarFileName = Guid.NewGuid() + "." + Path.GetFileName(profileViewModel.UploadedFile.FileName).Split('.').Last();
            using (var fileStream = new FileStream(Path.Combine(avatarUserPath, avatarFileName), FileMode.Create))
            {
                profileViewModel.UploadedFile.CopyTo(fileStream);
            }
            return Path.Combine(Constants.AvatarFolder, avatarFileName);
        }
    }
}
