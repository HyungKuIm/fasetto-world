using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ChatItem
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string Initials { get; set; }
        public string ProfilePictureRGB { get; set; }

        public ChatItem(string name, string message, 
            string intials, string profile)
        {
            this.Name = name;
            this.Message = message;
            this.Initials = intials;
            this.ProfilePictureRGB = profile;
        }
    }
}
