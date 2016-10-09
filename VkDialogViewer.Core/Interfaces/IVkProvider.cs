using System;
using System.Linq;
using VkDialogViewer.Core.Entities;
using VkDialogViewer.Core.Models.ViewModel;

namespace VkDialogViewer.Core.Interfaces
{
    public interface IVkProvider
    {
        IQueryable<VkMessage> GetVkMessages(MessageFilterModel filter);
    }
}
