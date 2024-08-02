
using System;
using System.Text.RegularExpressions;

namespace TestApp
{
    public class MatchDates
    {
        public static string Match(string? dates)
        {
            if (dates is null)
            {
                throw new ArgumentException("Input cannot be null!");
            }

            // Regular expression to match dates like 31-Dec-2022, 31/Dec/2022, 31 Dec 2022
            Regex pattern = new(@"\b(?<day>\d{2})(?<separator>[-.\/\s])(?<month>[A-Z][a-z]+)\k<separator>(?<year>\d{4})");

            MatchCollection matches = pattern.Matches(dates);
            foreach (Match match in matches)
            {
                string day = match.Groups["day"].Value;
                string month = match.Groups["month"].Value;
                string year = match.Groups["year"].Value;

                return $"Day: {day}, Month: {month}, Year: {year}";
            }

            return string.Empty;
        }
    }
}
