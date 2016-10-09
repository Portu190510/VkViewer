namespace VkDialogViewer.Core.Models.ViewModel
{
    public class MessageModel
    {
        public long MessageId { get; set; }

        public string DateTime { get; set; }

        public long FromUserId { get; set; }

        public long ToUserId { get; set; }

        public bool IsInbox { get; set; }

        public string UserName { get; set; }

        public string Body { get; set; }
    }
}