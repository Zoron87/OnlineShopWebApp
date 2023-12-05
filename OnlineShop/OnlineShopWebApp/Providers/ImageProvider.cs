using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace OnlineShopWebApp.Providers
{
    public class ImageProvider
    {
        private readonly IWebHostEnvironment _appEnvironent;

        public ImageProvider(IWebHostEnvironment appEnvironent)
        {
            _appEnvironent = appEnvironent;
        }

        public List<ImageViewModel> AddImages(ItemViewModel item, string imageProductsFolder)
        {
            var imagesViewModel = new List<ImageViewModel>();
            if (item.UploadedFiles != null)
            {
                foreach (var file in item.UploadedFiles)
                {
                    var productImagePath = Path.Combine(_appEnvironent.WebRootPath + imageProductsFolder);
                    if (!Directory.Exists(productImagePath))
                    {
                        Directory.CreateDirectory(productImagePath);
                    }

                    var imageFileName = Guid.NewGuid() + "." + file.FileName.Split('.').Last();
                    using (var fileStream = new FileStream(Path.Combine(productImagePath, imageFileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    imagesViewModel.Add(new ImageViewModel() { URL = Path.Combine(imageProductsFolder, imageFileName) });
                }
            }
            return imagesViewModel;
        }
    }
}
