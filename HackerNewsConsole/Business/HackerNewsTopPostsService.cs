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
            var topItems = topStoriesDataService.GetTopStories().Result.ToList();
            var rank = 1;
            var numItem = 0;
            
            while ((numItem < topItems.Count()) && (rank <= limitTo))
            {
                var item = itemDataService.GetItem(topItems[numItem]).Result;
                if (item.IsValidStory())
                {
                    yield return item.Map(rank++);
                }
                numItem++;
            }
        }
    }
}
