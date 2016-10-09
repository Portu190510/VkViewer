using System.Data.Entity;

namespace VkDialogViewer.DAL
{
    public class DbInitializer:DropCreateDatabaseIfModelChanges<VkViewerDbContext>
    {
        protected override void Seed(VkViewerDbContext context)
        {
        }
    }
}