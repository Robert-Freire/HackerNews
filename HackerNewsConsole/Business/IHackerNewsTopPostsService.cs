using System.Collections.Generic;
using HackerNewsConsole.Model;

namespace HackerNewsConsole.Business
{
    public interface IHackerNewsTopPostsService
    {
        IEnumerable<Story> GetTopItems(int limitTo);
    }
}