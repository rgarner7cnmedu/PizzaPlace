using PizzaPlace.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaPlace.Client.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient httpClient;
        public BlogService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<List<BlogEntry>> GetBlogEntries()
        {
            var blogEntries = await this.httpClient.GetFromJsonAsync<List<BlogEntry>>("api/BlogEntries");
            return blogEntries;
        }
    }
}
