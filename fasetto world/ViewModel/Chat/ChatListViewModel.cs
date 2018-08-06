using Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fasetto_world
{
    public class ChatListViewModel : BaseViewModel
    {
        

        public ObservableCollection<ChatListItemViewModel> Items { get; set; }

        public ChatListViewModel()
        {
            this.Items = new ObservableCollection<ChatListItemViewModel>();
        }

        public async Task SetChatListViewModel()
        {
            ChatListModel Model = new ChatListModel();
            await Model.GetChatList();
            this.Items.Clear();
            for (int i = 0; i < Model.Items.Count; i++)
            {
                ChatItem item = Model.Items[i];
                ChatListItemViewModel ViewModel = new ChatListItemViewModel();
                ViewModel.Name = item.Name;
                ViewModel.Message = item.Message;
                ViewModel.Initials = item.Initials;
                ViewModel.ProfilePictureRGB = item.ProfilePictureRGB;
                this.Items.Add(ViewModel);
            }

        }
    }
}
