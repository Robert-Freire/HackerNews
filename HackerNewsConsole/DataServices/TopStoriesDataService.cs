using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNewsConsole.DataServices
{
    /// <summary>
    /// Class TopStoriesDataService. Service to get the top stories from hacker news This class cannot be inherited.
    /// </summary>
    public class TopStoriesDataService : ITopStoriesDataService
    {
        /// <summary>
        /// The URL
        /// </summary>
        private readonly string url;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopStoriesDataService"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public TopStoriesDataService(String url)
        {
            this.url = url;
        }

        /// <summary>
        /// Gets the top stories.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;System.Int32&gt;&gt;.</returns>
        public async Task<IEnumerable<int>> GetTopStories()
        {
            using HttpClient client = new HttpClient();
            {
                var stream = await client.GetStreamAsync(this.url);
                using var sr = new StreamReader(stream);
                using var reader = new JsonTextReader(sr);

                var serializer = new JsonSerializer();
                return serializer.Deserialize<List<int>>(reader);
            }
        }
    }
}
