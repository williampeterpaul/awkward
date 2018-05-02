using awkward.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awkward.ui.Services
{
    public interface IApiClient
    {
        Task<List<Entity>> GetEntitiesAsync();
        Task<Entity> GetEntityAsync(int id);
        Task PutEntityAsync(Entity entity);
        Task AddEntityAsync(Entity entity);
    }
}
