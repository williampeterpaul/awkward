using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using awkward.api.Models;
using awkward.ui.Extensions;

namespace awkward.ui.Services
{
    public class AccountApiClient : IApiClient<ApplicationUser>
    {
        public AccountApiClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        private HttpClient HttpClient { get; }

        public async Task AddEntityAsync(ApplicationUser entity)
        {
            var response = await HttpClient.PostJsonAsync("/api/Account", entity);

            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ApplicationUser>> GetEntitiesAsync()
        {
            var response = await HttpClient.GetAsync("/api/Account");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<ApplicationUser>>();
        }

        public async Task<ApplicationUser> GetEntityAsync(int id)
        {
            var response = await HttpClient.GetAsync($"/api/Account/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<ApplicationUser>();
        }

        public async Task PutEntityAsync(ApplicationUser entity)
        {
            var response = await HttpClient.PutJsonAsync($"/api/Account/{entity.Id}", entity);

            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveEntityAsync(int id)
        {
            var response = await HttpClient.DeleteAsync($"/api/Account/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
