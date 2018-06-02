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
        public ApiClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        private HttpClient HttpClient { get; }

        public async Task AddEntityAsync(Media entity)
        {
            var response = await HttpClient.PostJsonAsync("/api/Entities", entity);

            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Media>> GetEntitiesAsync()
        {
            var response = await HttpClient.GetAsync("/api/Entities");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<Media>>();
        }

        public async Task<Media> GetEntityAsync(int id)
        {
            var response = await HttpClient.GetAsync($"/api/Entities/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<Media>();
        }

        public async Task PutEntityAsync(Media entity)
        {
            var response = await HttpClient.PutJsonAsync($"/api/Entities/{entity.Id}", entity);

            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveEntityAsync(int id)
        {
            var response = await HttpClient.DeleteAsync($"/api/Entities/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
