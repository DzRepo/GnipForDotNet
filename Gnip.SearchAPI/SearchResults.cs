using Gnip.Utilities.JsonClasses;

namespace Gnip.SearchAPI
{
    /// <summary>
    /// JSON class representation of data returned by SearchAPI
    /// </summary>
    public class Results
    {
        public string next;
        public Activity[] results;
    }

    /// <summary>
    /// JSON class representation of counts endpoint returned by SearchAPI
    /// </summary>
    public class Counts
    {
        public Intervals[] results;
    }

    /// <summary>
    /// JSON class representation of period data for counts endpoint returned by SearchAPI
    /// </summary>
    public class Intervals
    {
        public string timePeriod { get; set; }
        public int count { get; set; }
    }
}
