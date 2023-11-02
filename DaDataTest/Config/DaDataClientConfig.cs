namespace DaDataTest.Config
{
    public class DaDataClientConfig
    {
        public DaDataClientConfig(IConfiguration config)
        {
            config.Bind("DaDataClient", this);
        }

        public Uri BaseUrl { get; set; }

        public string ApiKey { get; set; }

        public string SecretToken { get; set; }

        public Dictionary<string, string> Headers { get; set; } 
    }
}
