using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Authentication
{
    public interface ILogin
    {
        Task<User> Validate(string un, string pw);
    }
}