using APITestProduct.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace APITestProduct.Data
{
    public interface IDataContext
    {
        DbSet<Product> Product { get; set; }
        DbSet<User> User { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
