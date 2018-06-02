using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using awkward.api.Models;
using awkward.ui.Extensions;

namespace awkward.ui.Services
{
    public class ContentApiClient : IApiClient<ApplicationContent>
    {
        public ContentApiClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        private HttpClient HttpClient { get; }

        public async Task AddEntityAsync(ApplicationContent entity)
        {
            var response = await HttpClient.PostJsonAsync("/api/Content", entity);

            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ApplicationContent>> GetEntitiesAsync()
        {
            var response = await HttpClient.GetAsync("/api/Content");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<ApplicationContent>>();
        }

        public async Task<ApplicationContent> GetEntityAsync(int id)
        {
            var response = await HttpClient.GetAsync($"/api/Content/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<ApplicationContent>();
        }

        public async Task PutEntityAsync(ApplicationContent entity)
        {
            var response = await HttpClient.PutJsonAsync($"/api/Content/{entity.Id}", entity);

            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveEntityAsync(int id)
        {
            var response = await HttpClient.DeleteAsync($"/api/Content/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
