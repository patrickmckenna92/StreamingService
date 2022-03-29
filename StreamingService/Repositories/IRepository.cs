using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Repositories
{

    // Both repositories required SaveChanges method so created a more general interface
    // Example of interface segregation.

    public interface IRepository
    {
        bool SaveChanges();
    }
}
