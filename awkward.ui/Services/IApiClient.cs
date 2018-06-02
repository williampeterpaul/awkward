using awkward.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awkward.ui.Services
{
    public interface IApiClient
    {
        Task<List<Media>> GetEntitiesAsync();
        Task<Media> GetEntityAsync(int id);
        Task PutEntityAsync(Media entity);
        Task AddEntityAsync(Media entity);
        Task RemoveEntityAsync(int id);
    }
}
