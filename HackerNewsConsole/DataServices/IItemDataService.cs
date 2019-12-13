using System.Threading.Tasks;
using HackerNewsConsole.Model;

namespace HackerNewsConsole.DataServices
{
    public interface IItemDataService
    {
        Task<HNItem> GetItem(int id);
    }
}