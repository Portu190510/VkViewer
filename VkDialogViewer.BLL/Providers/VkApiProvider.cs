using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkDialogViewer.Core.Constants;
using VkDialogViewer.Core.Interfaces;
using VkDialogViewer.Core.Models.VkModel;

namespace VkDialogViewer.BLL.Providers
{
    public class VkApiProvider : IVkApiProvider
    {
        public AccessTokenResponse ParseAccessToken(string url)
        {
            const string regx = @"#access_token=(.*)&expires_in=(.*)&user_id=(.*)$";
            var match = Regex.Match(url, regx, RegexOptions.IgnoreCase);

            return new AccessTokenResponse
            {
                AccessToken = match.Groups[1].ToString(),
                Expires = match.Groups[2].ToString(),
                UserId = match.Groups[3].ToString()
            };
        }

        /// <summary>
        /// Get message history for UserID
        /// https://vk.com/dev/messages.getHistory
        /// </summary>
        /// <param name="token"></param>
        /// <param name="count"></param>
        /// <param name="userId"></param>
        public IEnumerable<DialogMessage> LoadMessagesByUserId(string token, string userId, int count = 200, int offset = 0)
        {
            const string apiMethod = "messages.getHistory";
            var apiParams = "count={0}&user_id={1}&offset={2}&rev=1";
            apiParams = string.Format(apiParams, count, userId, offset);

            var messages = RequestToApi(apiMethod, apiParams, token);
            if (messages != null)
            {
                var a = JObject.Parse(messages);
                a["response"][0].Remove();
                return JsonConvert.DeserializeObject<DialogResponse>(a.ToString()).Response;
            }

            return new List<DialogMessage>();
        }

        public AccessTokenResponse Authorize(string userId)
        {
            var requestUrl = string.Format(VkConfigConstants.AuthUrl, userId, VkConfigConstants.Scope, VkConfigConstants.RedirectUrl);
            ;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(requestUrl);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.68 Safari/537.36 OPR/24.0.1558.34 (Edition Next)";
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";


                var response = (HttpWebResponse)request.GetResponse();
                var token = ParseAccessToken(response.ResponseUri.Fragment);
                return token;
            }
            catch (WebException e)
            {

            }
            return null;
        }

        private string RequestToApi(string method, string parameters, string token)
        {
            var requestUrl = string.Format(VkConfigConstants.ApiUrl, method, parameters, token);
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(requestUrl);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.68 Safari/537.36 OPR/24.0.1558.34 (Edition Next)";
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";


                var response = (HttpWebResponse)request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException e)
            {

            }
            return null;
        }
    }
}