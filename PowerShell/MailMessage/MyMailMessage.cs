using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShell.MailMessage
{
    public class MyMailMessage
    {
        [JsonProperty("message")]
        public Message message { get; set; }
        [JsonProperty("saveToSentItems")]
        public bool SaveToSentItems { get; set; } = false;
    }
}
