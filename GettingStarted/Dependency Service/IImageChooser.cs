using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted
{
    public interface IImageChooser
    {
        Task<bool> StartImageChooser();
        Stream GetImage();

    }
}
