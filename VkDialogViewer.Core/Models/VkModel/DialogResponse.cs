using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkDialogViewer.Core.Models.VkModel
{
    public class DialogResponse
    {
        [JsonProperty("response")]
        public IEnumerable<DialogMessage> Response { get; set; }
    }
}