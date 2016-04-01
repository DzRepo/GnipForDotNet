using System.Collections.Generic;

namespace Gnip.Utilities.JsonClasses
{
    public class Rule
    {
        public string value { get; set; }
        public string tag { get; set; }

        public string id { get; set; }  //  added for v2 products
        public override string ToString()
        {
            return tag;
        }
    }
}
