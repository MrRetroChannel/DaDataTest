

using System.Runtime.InteropServices;

namespace DaDataTest.Clients
{
    public class DaDataClient
    {
        private readonly HttpClient client;

        public DaDataClient(HttpClient client) => this.client = client;

        public async Task<string> PostAddress(string rawAddress)
        {
            return await (await client
                .PostAsync("clean/address", JsonContent.Create(new List<string>{ rawAddress })))
                .Content.ReadAsStringAsync();
        }

        public string Url { get => client.BaseAddress?.ToString() ?? ""; }
    }
}
