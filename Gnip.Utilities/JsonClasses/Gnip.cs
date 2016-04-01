// ReSharper disable InconsistentNaming

namespace Gnip.Utilities.JsonClasses
{
    public class Gnip
    {
        public Rule[] matching_rules;
        public URLs[] urls;
        public int klout_score;
        public KloutProfile klout_profile;
        public ProfileLocations[] profileLocations;
        public Language language;

        public string Matching_Rules()
        {
            var result = "";
            foreach (var rule in matching_rules)
                result += rule + ", ";

            result = result.TrimEnd(", ".ToCharArray());
            return result;

        }
    }

}
