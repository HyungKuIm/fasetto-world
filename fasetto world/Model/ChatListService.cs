using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace fasetto_world
{
    /// <summary>
    /// 채팅 목록 서비스
    /// </summary>
    public class ChatListService
    {
        public async Task<IEnumerable<ChatItem>> GetChatList()
        {
            using (var httpClient = new HttpClient())
            {
                var url = "http://localhost:56644/api/ChatList";
                var response = await httpClient.GetAsync(url);
                var jsonString = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<ChatItem[]>(jsonString);
                return item;
            }
        }
    }
}
