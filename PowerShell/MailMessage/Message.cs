using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShell.MailMessage
{
    public class Message
    {
        [JsonProperty("bccRecipients")]
        public IEnumerable<Recipient> BccRecipients { get; set; } = new List<Recipient>();
        [JsonProperty("body")]
        public MailBody Body { get; set; }
        [JsonProperty("ccRecipients")]
        public IEnumerable<Recipient> ccRecipients { get; set; } = new List<Recipient>();
        [JsonProperty("from")]

        public Recipient From { get; set; }
        [JsonProperty("hasAttachments")]
        public bool HasAttachments { get; set; } = false;
        [JsonProperty("replyTo")]
        public IEnumerable<Recipient> ReplyTo { get; set; } = new List<Recipient>();
        [JsonProperty("sender")]
        public Recipient Sender { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("toRecipients")]
        public IEnumerable<Recipient> ToRecipients { get; set; } = new List<Recipient>();
    }
}
