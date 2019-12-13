using HackerNewsConsole.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNewsConsole.DataServices
{
    /// <summary>
    /// Class ItemDataService.
    /// Implements the <see cref="HackerNewsConsole.DataServices.IItemDataService" />
    /// </summary>
    /// <seealso cref="HackerNewsConsole.DataServices.IItemDataService" />
    public class ItemDataService : IItemDataService
    {
        /// <summary>
        /// The URL
        /// </summary>
        private readonly string url;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDataService"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public ItemDataService(String url)
        {
            this.url = url;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;HNItem&gt;.</returns>
        public async Task<HNItem> GetItem(int id)
        {
            using HttpClient client = new HttpClient();
            {
                var stream = await client.GetStreamAsync(string.Format (this.url, id.ToString()));
                using var sr = new StreamReader(stream);
                using var reader = new JsonTextReader(sr);

                var serializer = new JsonSerializer();
                return serializer.Deserialize<HNItem>(reader);
            }
        }
    }
}
