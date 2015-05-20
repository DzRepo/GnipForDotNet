namespace Gnip.Utilities.JsonClasses
{
    public class Actor
    {
        public string objectType;
        public string id;
        public string link;
        public string displayName;
        public string image;
        public string summary;
        public string postedTime;
        public Link[] links;
        public long friendsCount;
        public long followersCount;
        public long listedCount;
        public long statusesCount;
        public long favoritesCount;
        public string twitterTimeZone;
        public bool verified;
        public string utcOffset;
        public string preferredUsername;
        public string[] languages;
        public Location location;
    }
}
