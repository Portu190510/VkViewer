using VkDialogViewer.Core.Models.Sync;
using VkDialogViewer.Core.Models.VkModel;

namespace VkDialogViewer.Core.Interfaces
{
    public interface IVkSyncProvider
    {
        bool SyncMessages(SyncMessageSettingsModel model, AccessTokenResponse token);
    }
}