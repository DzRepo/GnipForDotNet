using System;
using Newtonsoft.Json;  // necessary due to use of reserved "object" as name of embedded object data below.

namespace Gnip.Utilities.JsonClasses
{
    public class Activity
    {
        public string id;
        public Actor actor;
        public string verb;
        public Generator generator;
        public Provider provider;
        public InReplyTo inReplyTo;
        public Location location;
        public Geo geo;
        public Twitter_Entities twitter_entities;
        public Twitter_Extended_Entities twitter_extended_entities;
        public string link;
        public string body;
        public string objectType;
        // object is a reserved word, so need to indicate it's JSON name via attribute.
        [JsonProperty("object")]
        public ActivityObject activityObject;
        public DateTime postedTime;
        public long favoritesCount;
        public string twitter_filter_level;
        public string twitter_lang;
        public long retweetCount;
        public Gnip gnip;
        public Activity twitter_quoted_status;  // will contain full Activity Object of Tweet that was quoted
    }
}
