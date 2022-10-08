namespace PowerShell
{
    public class AuthToken
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("ext_expires_in")]
        public int ExtendedExpires { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonIgnore]
        public string QueryToken => $"{TokenType} {AccessToken}";
    }
}
