using System.Threading.Tasks;
using WebClient.Models;


namespace WebClient.Data
{
    public interface IUserService
    {
        Task<User> ValidateLogin(string username, string password);
        Task<User> CreateAccount(User newUser);
    }
}