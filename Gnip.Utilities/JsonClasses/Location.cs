namespace Gnip.Utilities.JsonClasses
{
    public class Location
    {
        public string objectType;
        public string displayName;
        public string name;
        public string country_code;
        public string twitter_country_code;
        public string twitter_place_type;  // values may be: "country", "admin", "city", "neighborhood, "poi"
        public string link;
        public Geo geo;
        public string streetAddress;
    }
}
