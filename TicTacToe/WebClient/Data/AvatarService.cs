using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    
    
    public class AvatarService : IAvatarService
    {
        private readonly HttpClient client;
        private string uri = "https://localhost:5003";
        private Avatar localAvatar;

        public AvatarService()
        {
            client = new HttpClient();
        }
        
        public async Task<Avatar> GetAvatarAsync(int id)
        {
            HttpResponseMessage rMsg = await client.GetAsync($"{uri}/Avatars/{id}");

            if (!rMsg.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {rMsg.StatusCode}, {rMsg.ReasonPhrase}");
            }

            string jsonAvatar = await rMsg.Content.ReadAsStringAsync();
            
            Avatar a = JsonSerializer.Deserialize<Avatar>(jsonAvatar, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            localAvatar = a;

            return a;
        }

        public async Task<Status> GetAvatarStatusAsync(int id)
        {
            Status s = 
        }
    }
}
