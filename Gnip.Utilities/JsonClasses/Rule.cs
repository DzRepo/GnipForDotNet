using System.Collections.Generic;

namespace Gnip.Utilities.JsonClasses
{
    public class Rule
    {
        public string value { get; set; }
        public string tag { get; set; }
        public override string ToString()
        {
            return tag;
        }
    }
}
