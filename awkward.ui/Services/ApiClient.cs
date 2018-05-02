using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using awkward.api.Models;
using awkward.ui.Extensions;

namespace awkward.ui.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _HttpClient;

        public ApiClient(HttpClient HttpClient)
        {
            _HttpClient = HttpClient;
        }

        public async Task AddEntityAsync(Entity entity)
        {
            var response = await _HttpClient.PostJsonAsync("/api/Entities", entity);

            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Entity>> GetEntitiesAsync()
        {
            var response = await _HttpClient.GetAsync("/api/Entities");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<Entity>>();
        }

        public async Task<Entity> GetEntityAsync(int id)
        {
            var response = await _HttpClient.GetAsync($"/api/Entities/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<Entity>();
        }

        public async Task PutEntityAsync(Entity entity)
        {
            var response = await _HttpClient.PutJsonAsync($"/api/Entities/{entity.Id}", entity);

            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveTripAsync(int id)
        {
            var response = await _HttpClient.DeleteAsync($"/api/Entities/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
