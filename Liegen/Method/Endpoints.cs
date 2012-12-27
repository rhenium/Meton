namespace Meton.Liegen.Method
{
    public static class Endpoints
    {
        // Base uri
        public static string BaseUriOAuth = "https://twitter.com/oauth/";
        public static string BaseUriApiV11 = "https://api.twitter.com/1.1/";
        public static string BaseUriUserStreamsV11 = "https://userstream.twitter.com/1.1/";
        public static string BaseUriUrlsV1 = "http://urls.api.twitter.com/1/";
        public static string BaseUriApiV1 = "https://api.twitter.com/1/";
        public static string BaseUriApiI = "https://api.twitter.com/i/";

        // OAuth
        public static string OAuthRequestTokenUrl = Endpoints.BaseUriOAuth + "request_token";
        public static string OAuthAccessTokenUrl = Endpoints.BaseUriOAuth + "access_token";
        public static string OAuthAuthorizeUrl = Endpoints.BaseUriOAuth + "authorize";

        // Streaming
        public static string UserStream = Endpoints.BaseUriUserStreamsV11 + "user.json";

        // statuses/
        public static string StatusesHomeTimeline = Endpoints.BaseUriApiV11 + "statuses/home_timeline.json";
        public static string StatusesUpdate = Endpoints.BaseUriApiV11 + "statuses/update.json";
        public static string StatusesUpdateWithMedia = Endpoints.BaseUriApiV11 + "statuses/update_with_media.json";

        // users/
        public static string UsersShow = Endpoints.BaseUriApiV11 + "users/show.json";
        public static string UsersLookup = Endpoints.BaseUriApiV11 + "users/lookup.json";

        // application/
        public static string ApplicationRateLimitStatus = Endpoints.BaseUriApiV11 + "application/rate_limit_status.json";

        // activity
        public static string ActivityStatusSummary = Endpoints.BaseUriApiI + "statuses/:id/activity/summary.json";


        // *
        public static string AccountGenerate = Endpoints.BaseUriApiV1 + "account/generate.json";

        public static string UrlsShorten = Endpoints.BaseUriUrlsV1 + "urls/shorten.json";
        public static string UrlsCount = Endpoints.BaseUriUrlsV1 + "urls/count.json";
    }
}
