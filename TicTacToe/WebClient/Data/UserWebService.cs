using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Data;
using WebClient.Models;

namespace WebClient.Data
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
                Console.WriteLine(userAsJson.ToString());
                Console.WriteLine(resultUser.Password);
                Console.WriteLine(resultUser.Username);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return resultUser;
                }else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Invalid Password");
                }
            throw new Exception("User not found");
        }
    }
}