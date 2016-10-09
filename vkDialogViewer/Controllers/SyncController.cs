using System.Web.Mvc;
using VkDialogViewer.Core.Interfaces;
using VkDialogViewer.Core.Models.Sync;
using VkDialogViewer.Core.Models.VkModel;

namespace vkDialogViewer.Controllers
{
    public class SyncController : BaseController
    {
        private const string USER_TOKEN = "USER_TOKEN";
        private readonly IVkSyncProvider syncProvider;
        private readonly IVkApiProvider vkApiProvider;

        public SyncController(IVkSyncProvider syncProvider, IVkApiProvider vkApiProvider)
        {
            this.syncProvider = syncProvider;
            this.vkApiProvider = vkApiProvider;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public JsonResult ConnectToVk(string userId)
        {
            var token = this.vkApiProvider.Authorize(userId);
            if (token != null)
            {
                Session[USER_TOKEN] = token;
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }

            return this.Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult StartSyncMessages(int iterattionsCount)
        {
            var operationStatus = this.syncProvider.SyncMessages(new SyncMessageSettingsModel
            {
                SyncMessageCount = iterattionsCount
            }, (AccessTokenResponse)Session[USER_TOKEN]);
            return this.Json(operationStatus, JsonRequestBehavior.AllowGet);
        }
    }
}