using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGenerator.Interfaces
{
    public interface IImageService
    {
        byte[] GenerateImage(int width, int height);
    }
}
