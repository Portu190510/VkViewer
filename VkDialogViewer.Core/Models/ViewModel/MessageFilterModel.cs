using System;

namespace VkDialogViewer.Core.Models.ViewModel
{
    public class MessageFilterModel
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public string SearchMask { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}