using awkward.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awkward.ui.Services
{
    public interface IApiClient<T>
    {
        Task<List<T>> GetEntitiesAsync();
        Task<T> GetEntityAsync(int id);
        Task PutEntityAsync(T entity);
        Task AddEntityAsync(T entity);
        Task RemoveEntityAsync(int id);
    }
}
