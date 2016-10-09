using System.Collections.Generic;

namespace VkDialogViewer.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Message> InboxMessages { get; set; }

        public virtual ICollection<Message> OutboxMessages { get; set; }

        public User()
        {
            this.InboxMessages = new List<Message>();
            this.OutboxMessages = new List<Message>();
        }
    }
}