using System.Net.Mail;
using Newtonsoft.Json;
using PowerShell;
using PowerShell.MailMessage;

internal class Program
{
    private static void Main(string[] args)
    {
        Guid TenantID = new Guid("934c17c2-5648-4043-a37d-a4571c9abdb0");
        Guid ClientId = new Guid("5785b19e-c212-4098-866a-c5982b778077");
        string secret = "QAp8Q~9kJynTUiIXRx4iduFkvMkqVhY_05QdyaOh";

        Auth a = new Auth(TenantID, ClientId, secret);
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
        using (HttpClient client = new HttpClient())
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "https://graph.microsoft.com/v1.0/me/sendMail");
            req.Headers.Add("Authorization", a.Token.QueryToken);
            req.Content = new StringContent(mail);
            req.Content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage resp = client.SendAsync(req).Result;

            if (!resp.IsSuccessStatusCode)
            {
                string error = resp.Content.ReadAsStringAsync().Result;
            }
        }
    }
}