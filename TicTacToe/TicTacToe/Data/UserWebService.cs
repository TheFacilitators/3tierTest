using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Data
{
    public class UserWebService : IUserService
    {
        public async Task<User> ValidateLogin(string username, string password)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            
            HttpClient client = new HttpClient();
            
            HttpResponseMessage response = await client.GetAsync($"http://localhost:8080/users/{username}?password={password}");
           
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson,options);
                
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return resultUser;
                }else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Invalid Password");
                }
            throw new Exception("User not found");
        }

        public async Task<User> CreateAccount(User newU)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            
            HttpClient client = new HttpClient();

            string userJson = JsonSerializer.Serialize(newU, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            HttpContent content = new StringContent(userJson, Encoding.UTF8, "application/json");
            
            Console.WriteLine(content.ToString());
            
            HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:8080/users", content);
            //log time herE? close to c#
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            return newU;
        }
    }
}