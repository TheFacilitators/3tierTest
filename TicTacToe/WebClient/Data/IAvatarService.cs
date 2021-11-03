using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface IAvatarService
    {
        Task<Avatar> GetAvatarAsync(int id);

        Task<Status> GetAvatarStatusAsync(int id);
    }
}