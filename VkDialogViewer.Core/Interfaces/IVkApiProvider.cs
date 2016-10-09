using System.Collections.Generic;
using VkDialogViewer.Core.Models.VkModel;

namespace VkDialogViewer.Core.Interfaces
{
    public interface IVkApiProvider
    {
        AccessTokenResponse ParseAccessToken(string url);

        IEnumerable<DialogMessage> LoadMessagesByUserId(string token, string userId, int count = 200, int offset = 0);

        AccessTokenResponse Authorize(string userId);
    }
}
