using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution937
{
    /// <summary>
    /// 937. Reorder Data in Log Files - Medium
    /// <a href="https://leetcode.com/problems/reorder-data-in-log-files">See the problem</a>
    /// </summary>
    public string[] ReorderLogFiles(string[] logs)
    {
        var letterLogs = new List<string>();
        var digitLogs = new List<string>();

        // Step 1: Separate letter-logs and digit-logs
        foreach (var log in logs)
        {
            var parts = log.Split(' ', 2);
            var identifier = parts[0];
            var content = parts[1];

            if (char.IsDigit(content[0]))
            {
                digitLogs.Add(log);
            }
            else
            {
                letterLogs.Add(log);
            }
        }

        // Step 2: Sort letter-logs
        letterLogs.Sort((log1, log2) =>
        {
            var parts1 = log1.Split(' ', 2);
            var parts2 = log2.Split(' ', 2);

            var content1 = parts1[1];
            var content2 = parts2[1];
            var identifier1 = parts1[0];
            var identifier2 = parts2[0];

            int cmp = content1.CompareTo(content2);
            if (cmp != 0)
            {
                return cmp;
            }

            // If contents are the same, compare by identifier
            return identifier1.CompareTo(identifier2);
        });

        // Step 3: Combine results
        letterLogs.AddRange(digitLogs);
        return [.. letterLogs];
    }
}
