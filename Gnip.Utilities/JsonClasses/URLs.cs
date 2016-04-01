// ReSharper disable InconsistentNaming
namespace Gnip.Utilities.JsonClasses
{
    public class URLs
    {
        public string url;
        public string expanded_url;
        public string expanded_url_description;
        public string expanded_url_title;
        public string display_url;
        public int[] indicies;
        public int? expanded_status; // used by Gnip class.  ? makes it nullable
    }
}
