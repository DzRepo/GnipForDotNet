namespace Gnip.Powertrack.Rules
{
    public static class UrlBuilder
    {
        public static string RuleUrl(
            string accountName, 
            string streamName, 
            bool isPowerTrack20 = false, 
            bool isReplay = false)
        {
            if (isPowerTrack20)
            {
                if (isReplay)
                {
                    // https://gnip-api.twitter.com/rules/powertrack-replay/accounts/ACCOUNTNAME/publishers/twitter/LABEL.json
                    return (@"https://gnip-api.twitter.com/rules/powertrack-replay/accounts/"
                            + accountName
                            + @"/publishers/twitter/"
                            + streamName
                            + @".json"
                        );                    
                }    
                return (@"https://gnip-api.twitter.com/rules/powertrack/accounts/"
                        + accountName
                        + @"/publishers/twitter/"
                        + streamName
                        + @".json"
                    );
            }
            if (isReplay)
            {
                // https://api.gnip.com:443/accounts/ACCOUNTNAME/publishers/twitter/replay/track/LABEL/rules.json
                return (@" https://api.gnip.com:443/accounts/"
                        + accountName
                        + @"/publishers/twitter/replay/track/"
                        + streamName
                        + @"/rules.json");
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

