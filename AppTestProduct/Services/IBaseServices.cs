using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITestProduct.Services
{
    public interface IBaseServices<T> where T : class
    {
        Task<T> Get(int Id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T obj);
        Task Delete(int Id);
        Task Update(T obj);
    }
}
