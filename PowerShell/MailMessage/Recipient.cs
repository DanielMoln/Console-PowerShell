using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShell.MailMessage
{
    public class Recipient
    {
        [JsonProperty("emailAddress")]
        public EmailAddress RecipientAddress { get; set; }

    }
}
