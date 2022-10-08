using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShell.MailMessage
{
    public class MailBody
    {
        [JsonProperty("contentType")]
        public string ContentType { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
