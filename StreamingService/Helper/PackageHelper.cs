using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamingService.Models;
namespace StreamingService.Helper
{
    public class PackageHelper : IPackageHelper
    {
        public int CalculateFreeSongs(Packages package)
        {
            if (Packages.Freemium == package)
            {
                return 3;
            }
            else if (Packages.Premium == package)
            {
                return 3 * 5;
            }
        }
    }
}
