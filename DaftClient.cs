using DaftIeLibNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DaftIeLibNET
{
    internal class DaftClient
    {
        private HttpClient client;

        public DaftClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Globals.ApiUrl);
            client.DefaultRequestHeaders.Add("brand", "daft");
            client.DefaultRequestHeaders.Add("platform", "web");
            client.DefaultRequestHeaders.Host = "gateway.daft.ie";
            client.DefaultRequestHeaders.Add("Origin", "https://www.daft.ie");
        }

        public async Task<string> GetListingsResults(string resultsType, int pageNum, int pageSize)
        {
            if (pageSize > 50 || pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", "Cannot be greater than 50 or less than 1");
            if (pageNum < 1)
                throw new ArgumentOutOfRangeException("pageNum", "Must be greater than 0");

            int from = (pageNum - 1) * pageSize;

            DaftListingsRequest request = new DaftListingsRequest()
            {
                Section = resultsType,
                Filters = new DaftListingsRequestFilter[]
                {
                    new DaftListingsRequestFilter
                    {
                        Name = "adState",
                        Values = new string[] { "published" }
                    }
                },
                Paging = new DaftListingsRequestPaging() { From = from, PageSize = pageSize },
                Sort = "publishDateDesc"
            };
            var response = await client.PostAsJsonAsync(new Uri(new Uri(Globals.ApiUrl), "listings"), request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
