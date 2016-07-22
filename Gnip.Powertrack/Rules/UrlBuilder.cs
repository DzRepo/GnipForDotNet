namespace Gnip.Powertrack.Rules
{
    public static class UrlBuilder
    {
        public static string RuleUrl(string accountName, string streamName, bool isPowerTrack20 = false)
        {
            if (isPowerTrack20)
            {
                return (@"https://gnip-api.twitter.com/rules/powertrack/accounts/"
                        + accountName
                        + @"/publishers/twitter/"
                        + streamName
                        + @".json"
                    );
            }
            return
                (@"https://api.gnip.com:443/accounts/"
                 + accountName
                 + @"/publishers/twitter/streams/track/"
                 + streamName
                 + @"/rules.json"
                  );
        }
    }
}

