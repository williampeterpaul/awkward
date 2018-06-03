using System.Collections.Generic;
using System.Threading.Tasks;

namespace awkward.ui.Services
{
    public interface IApiClient<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task PutAsync(T value);
        Task AddAsync(T value);
        Task RemoveAsync(int id);
    }
}
