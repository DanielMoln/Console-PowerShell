using PowerShell.MailMessage;

namespace PowerShell
{
    [Cmdlet("Send", "0365Mail")] // Send-0365Mail
    public class PsModule : PSCmdlet
    {
        public Guid TenantId { get; set; }
        public Guid ClientId { get; set; }
        public string ClientSecret { get; set; }

        /*Guid TenantID = new Guid("934c17c2-5648-4043-a37d-a4571c9abdb0");
        Guid ClientId = new Guid("5785b19e-c212-4098-866a-c5982b778077");
        string secret = "QAp8Q~9kJynTUiIXRx4iduFkvMkqVhY_05QdyaOh";*/

        protected void ProcessRecord()
        {
            Auth a = new Auth(this.TenantId, this.ClientId, this.ClientSecret);
            a.Authenticate();

            MyMailMessage mailMessage = new MyMailMessage()
            {
                message = new Message()
                {
                    Body = new MailBody()
                    {
                        Content = "Hello",
                        ContentType = "text/plain",
                    },
                    Subject = "Hello from C#",
                    From = new Recipient()
                    {
                        RecipientAddress = new EmailAddress()
                        {
                            Address = "vagr@ntszki.hu",
                            Name = "Varga Gábor"
                        }
                    }
                }
            };

            string mail = JsonConvert.SerializeObject(mailMessage);
        }

    }
}
