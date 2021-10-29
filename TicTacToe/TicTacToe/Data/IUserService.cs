using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Data
{
    public interface IUserService
    {
        Task<User> ValidateLogin(string username, string password);
    }
}