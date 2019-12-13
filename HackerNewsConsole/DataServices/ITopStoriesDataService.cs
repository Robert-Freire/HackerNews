using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// The DataServices namespace.
/// </summary>
namespace HackerNewsConsole.DataServices
{
    /// <summary>
    /// Interface ITopStoriesDataService
    /// </summary>
    public interface ITopStoriesDataService
    {
        /// <summary>
        /// Gets the top stories.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;System.Int32&gt;&gt;.</returns>
        Task<IEnumerable<int>> GetTopStories();
    }
}