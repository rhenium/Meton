using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Account.Generate
{
    public class Result
    {
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        public Result(string accessToken, string accessSecret)
        {
            this.AccessToken = accessToken;
            this.AccessTokenSecret = accessSecret;
        }
    }
}
