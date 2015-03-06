using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Gnip.Utilities.JsonClasses;

namespace Gnip.Powertrack.Rules
{
    public static class Extension
    {
        public static string ToJson(this List<Rule> ruleList)
        {
            const string jsonBodyStart = @"{""rules"":[";
            var ruleBody = new StringBuilder(jsonBodyStart);
            var addBody = new StringBuilder(jsonBodyStart);

            foreach (var rule in ruleList)
            {
                var ruleToMake = rule.value;
                ruleToMake = ruleToMake.Replace(@"""", @"\""");
                ruleBody.Append(@"{""value"":""" + ruleToMake + @"""},");
            }
            var ruleJson = ruleBody.ToString().Substring(0, ruleBody.Length - 1) + @"]}";
            Debug.WriteLine("ToJson=" + ruleJson);
            return ruleJson;
        }
    }
}
