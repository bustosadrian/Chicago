using Promotions.Model.Entities;
using System.Collections.Generic;

namespace Promotions.Interfaces.Repositories
{
    public interface ISKURepository
    {
        IEnumerable<SKU> List();
    }
}
