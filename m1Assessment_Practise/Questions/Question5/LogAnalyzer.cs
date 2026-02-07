using System.Text.RegularExpressions;

namespace m1Assessment_Practise.Questions.Question5;

class LogAnalyzer
{
    public IEnumerable<ErrorSummary> GetTopErrors(string filePath, int topN)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Log file not found", filePath);

        var errorCounts = new Dictionary<string, int>();
        var errorPattern = new Regex(@"ERR\d+", RegexOptions.Compiled);

        foreach (var line in File.ReadLines(filePath))
        {
            var matches = errorPattern.Matches(line);
            foreach (Match match in matches)
            {
                string errorCode = match.Value;
                errorCounts[errorCode] = errorCounts.GetValueOrDefault(errorCode, 0) + 1;
            }
        }

        return errorCounts
            .OrderByDescending(kvp => kvp.Value)
            .Take(topN)
            .Select(kvp => new ErrorSummary { ErrorCode = kvp.Key, Count = kvp.Value });
    }
}
