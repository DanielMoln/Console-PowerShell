namespace PowerShell
{
    public class Auth
    {
        public Guid TenantId { get; private set; }
        public Guid ClientId { get; private set; }
        public string ClientSecret { get; private set; }
        public AuthToken Token { get; private set; }

        public Auth(Guid tenantId, Guid clientId, string clientSecret)
        {
            TenantId = tenantId;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public async void Authenticate()
        {
            string body = $"client_id={ClientId}&scope=https%3A%2F%2Fgraph.microsoft.com" +
                $"%2F.default&client_secret={ClientSecret}&grant_type=client_credentials";
            string url = $"https://login.microsoftonline.com/{TenantId}/oauth2/v2.0/token";

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = new StringContent(body);
                request.Content.Headers.ContentType.MediaType = "application/x-www-form-urlencoded";
                try
                {
                    HttpResponseMessage response = client.Send(request);
                    if (response.IsSuccessStatusCode)
                    {
                        string msg = await response.Content.ReadAsStringAsync();
                        this.Token = JsonConvert.DeserializeObject<AuthToken>(msg);
                    }
                } catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }
            }
        }
    }
}
