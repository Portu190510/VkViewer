using System;

namespace VkDialogViewer.Core.Entities
{
    public class Message : BaseEntity
    {
        public DateTime DateTime { get; set; }

        public long FromUserId { get; set; }

        public long ToUserId { get; set; }

        public string Body { get; set; }

        public virtual User FromUser { get; set; }

        public virtual User ToUser { get; set; }
    }
}