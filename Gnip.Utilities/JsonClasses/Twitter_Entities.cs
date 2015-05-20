using System.Linq;

namespace Gnip.Utilities.JsonClasses
{
    public class Twitter_Entities
    {
        public Hashtag[] hashtags;
        public Symbols[] symbols;
        public URLs[] urls;
        public User_Mention[] user_mentions;
        public Media[] media;

        /// <summary>
        /// Returns an aggregated view of hashtags as a single field.
        /// </summary>
        /// <returns></returns>
        public string Hashtags()
        {
            string returnValue = "";
            if (hashtags.Length > 0)
            {
                foreach (var hashtag in hashtags)
                    returnValue += hashtag.text + ", ";
             
                returnValue = returnValue.TrimEnd(", ".ToCharArray());
            }
            return returnValue;
        }

        public string User_Mentions()
        {
            string returnValue = "";
            if (user_mentions.Length > 0)
            {
                foreach (var user_mention in user_mentions)
                    returnValue += user_mention.screen_name + ", ";

                returnValue = returnValue.TrimEnd(", ".ToCharArray());
            }
            return returnValue;
        }
        public string Urls()
        {
            string returnValue = "";
            if (urls.Length > 0)
            {
                foreach (var url in urls)
                    returnValue += url.expanded_url + ", ";
                returnValue = returnValue.TrimEnd(", ".ToCharArray());
            }
            return returnValue;
        }
    }
    
}
