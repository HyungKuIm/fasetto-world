using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fasetto_world
{
    public class ChatListModel
    {
        private List<ChatItem> items = new List<ChatItem>();

        public List<ChatItem> Items { get { return this.items; } }

        public async Task GetChatList()
        {
            this.Items.Clear();
            var results = await new ChatListService().GetChatList();
            foreach (var item in results)
            {
                this.Items.Add(item);
            }
        }
    }
}
