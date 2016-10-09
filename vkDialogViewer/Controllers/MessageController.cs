using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using VkDialogViewer.Core.Entities;
using VkDialogViewer.Core.Interfaces;
using VkDialogViewer.Core.Models.ViewModel;

namespace vkDialogViewer.Controllers
{
    public class MessageController : BaseController
    {
        private readonly IVkProvider vkProvider;

        public MessageController(IVkProvider vkProvider)
        {
            this.vkProvider = vkProvider;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMessageList(MessageFilterModel filter)
        {
            var messageListDb = this.vkProvider.GetVkMessages(filter);
            var messageList = Mapper.Map<List<VkMessage>,List<MessageModel>>(messageListDb.ToList());

            var model = new MessageViewModel
            {
                MessageList = messageList,
                TotalItemCount = messageList.Count()

            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
