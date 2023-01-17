using System.Text.RegularExpressions;

namespace Crack.xSource
{
    public class RegexHelpers
    {
        public static string WildCardToRegex(string searchPattern)
        {
            return "^" + Regex.Escape(searchPattern)
                                    .Replace("\\?", ".")
                                    .Replace("\\*", ".*") + "$";
        }
    }
}
