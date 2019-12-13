using HackerNewsConsole.DataServices;
using HackerNewsConsole.Model;
using System.Collections.Generic;

using System.Linq;

namespace HackerNewsConsole.Business
{
    public class HackerNewsTopPostsService : IHackerNewsTopPostsService
    {
        private readonly ITopStoriesDataService topStoriesDataService;
        private readonly IItemDataService itemDataService;
        public HackerNewsTopPostsService(ITopStoriesDataService topStoriesDataService, IItemDataService itemDataService)
        {
            this.topStoriesDataService = topStoriesDataService;
            this.itemDataService = itemDataService;
        }

        public IEnumerable<Story> GetTopItems(int limitTo)
        {
            var topItems = topStoriesDataService.GetTopStories().Result;
            var rank = 1;
            foreach (var item in topItems.Take(limitTo))
            {
                yield return itemDataService.GetItem(item).Result.Map(rank++);
            }
        }
    }
}
