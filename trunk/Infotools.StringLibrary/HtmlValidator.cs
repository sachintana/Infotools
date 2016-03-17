using System;
using System.Linq;

namespace Infotools.StringLibrary
{
    public class HtmlValidator
    {
        private const string LessThan = "<";
        private const string GreaterThan = ">";
        private const string LessThanEndTag = "</";
        private static string[] SingleSidedTags = new string[] { "IMG", "BR", "HR" };

        public static void Validate(string html)
        {
            string startingTag = "#";
            string endingTag = "#";

            // Starting tag indexes
            int startingTagStartIndex = html.IndexOf(LessThan);
            int startingTagEndIndex = html.IndexOf(GreaterThan);

            if (startingTagStartIndex >= 0 && startingTagEndIndex >= 0)
            {
                startingTag = html.Substring(startingTagStartIndex + 1, startingTagEndIndex - startingTagStartIndex - 1);

                // Trim attributes of the starting tag e.g. <img src="img.jpg" />
                string startingTagOnly = TrimAttributes(startingTag);

                // To validate single-sided tags
                if (startingTag.Substring(startingTag.Length - 1, 1) == "/" && SingleSidedTags.Contains(startingTagOnly.ToUpperInvariant()))
                {
                    // Valid single-sided tag found
                    string htmlNow = html.Substring(startingTagEndIndex + 1, html.Length - startingTagEndIndex - 1);

                    // Iterate through remaining HTML
                    Validate(htmlNow);
                }
                else
                {
                    // Find out ending tag's start and end index
                    int endTagStartIndex = html.LastIndexOf(LessThanEndTag);
                    int endTagEndIndex = html.LastIndexOf(GreaterThan);

                    if (endTagStartIndex >= 0 && endTagEndIndex >= 0)
                    {
                        endingTag = html.Substring(endTagStartIndex + 2, endTagEndIndex - endTagStartIndex - 2);
                    }

                    if (startingTagOnly != "#" && endingTag != "#" && startingTagOnly.ToUpperInvariant() == endingTag.ToUpperInvariant())
                    {
                        // Valid start tag and end tag found
                        string htmlNow = html.Substring(startingTagEndIndex + 1, endTagStartIndex - startingTagEndIndex - endingTag.Length);

                        // Iterate through remaining HTML
                        Validate(htmlNow);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("Expected {0}, found {1}", startingTagOnly, endingTag));
                    }
                }
            }
            else
            {
                Console.WriteLine("Correctly tagged paragraph");
            }
        }

        /// <summary>
        /// Trim attributes of the starting tag e.g. <img src="img.jpg" />
        /// </summary>
        /// <param name="startingTag"></param>
        /// <returns></returns>
        private static string TrimAttributes(string startingTag)
        {
            int spaceIndex = startingTag.IndexOf(" ");
            string startingTagOnly = string.Empty;

            if (spaceIndex >= 0)
            {
                startingTagOnly = startingTag.Substring(0, spaceIndex);
            }
            else
            {
                startingTagOnly = startingTag;
            }
            return startingTagOnly;
        }
    }
}