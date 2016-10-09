using System.Collections.Generic;

namespace VkDialogViewer.Core.Models.ViewModel
{
    public class MessageViewModel
    {
        public IEnumerable<MessageModel> MessageList { get; set; }

        public int TotalItemCount { get; set; } 
    }
}