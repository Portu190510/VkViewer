namespace VkDialogViewer.Core.Models.Sync
{
    public class SyncMessageSettingsModel
    {
        public int OwnerUserId { get; set; }

        public int OpponentUserId { get; set; }

        public int AllredySyncedMessageCount { get; set; }

        public int NotSyncedMessageCount { get; set; }

        public int SyncMessageCount { get; set; }
    }
}