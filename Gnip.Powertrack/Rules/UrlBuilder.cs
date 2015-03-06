namespace Gnip.Powertrack.Rules
{
    public static class UrlBuilder
    {
        public static string RuleUrl(string accountName, string streamName)
        {
            return
                (@"https://api.gnip.com:443/accounts/"
                 + accountName
                 + @"/publishers/twitter/streams/track/"
                 + streamName
                 + @"/rules.json}"
                    );
        }
    }
}
