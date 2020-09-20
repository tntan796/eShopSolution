using System.IO;
using System.Threading.Tasks;

namespace eShopSolution.Application.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);
        Task SaveFileAsync(Stream mediaBinaryStram, string fileName);
        Task DeleteAsync(string fileName);
    }
}
