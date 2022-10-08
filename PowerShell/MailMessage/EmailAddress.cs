using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShell.MailMessage
{
    public class EmailAddress
    {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
