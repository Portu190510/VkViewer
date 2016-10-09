namespace VkDialogViewer.Core.Constants
{
    public class VkConfigConstants
    {
        public const string AuthUrl = "https://oauth.vk.com/authorize?client_id={0}&scope={1}&redirect_uri={2}&display=page&v=5.24&response_type=token";
        public const string ApiUrl = "https://api.vk.com/method/{0}?{1}&access_token={2}";
        public const string RedirectUrl = "https://oauth.vk.com/blank.html";

        public const string Scope = "messages";
    }
}