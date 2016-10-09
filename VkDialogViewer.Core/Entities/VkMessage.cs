using System.Collections.Generic;

namespace VkDialogViewer.Core.Entities
{
    public class VkMessage :BaseEntity
    {
        public string Body { get; set; }

        public int UserId { get; set; }

        public int FromId { get; set; }

        public int Date { get; set; }

        public int ReadState { get; set; }

        public int Out { get; set; }

        public object Attachment { get; set; }

        public object Attachments { get; set; }

        public IEnumerable<VkMessage> ForwardMessages { get; set; }
    }
}