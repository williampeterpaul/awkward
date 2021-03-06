﻿using awkward.api.Models;
using awkward.ui.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace awkward.ui.Services
{
    public class AccountApiClient : IApiClient<ApplicationUser>
    {
        public AccountApiClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        private HttpClient HttpClient { get; }

        public async Task AddAsync(ApplicationUser value)
        {
            var response = await HttpClient.PostJsonAsync("/api/Account", value);

            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ApplicationUser>> GetAsync()
        {
            var response = await HttpClient.GetAsync("/api/Account");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<ApplicationUser>>();
        }

        public async Task<ApplicationUser> GetAsync(int id)
        {
            var response = await HttpClient.GetAsync($"/api/Account/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<ApplicationUser>();
        }

        public async Task PutAsync(ApplicationUser value)
        {
            var response = await HttpClient.PutJsonAsync($"/api/Account/{value.Id}", value);

            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveAsync(int id)
        {
            var response = await HttpClient.DeleteAsync($"/api/Account/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
