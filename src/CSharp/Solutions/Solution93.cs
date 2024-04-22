using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution93
{
    /// <summary>
    /// 93. Restore IP Addresses - Medium
    /// <a href="https://leetcode.com/problems/restore-ip-addresses">See the problem</a>
    /// </summary>
    public IList<string> RestoreIpAddresses(string s)
    {
        var result = new List<string>();
        var path = new List<string>();

        RestoreIpAddresses(s, 0, path, result);

        return result;
    }
    
    private void RestoreIpAddresses(string s, int start, List<string> path, List<string> result)
    {
        if (path.Count == 4 && start == s.Length)
        {
            result.Add(string.Join('.', path));
            return;
        }

        if (path.Count == 4 || start == s.Length)
        {
            return;
        }

        for (var i = 1; i <= 3 && start + i <= s.Length; i++)
        {
            var part = s.Substring(start, i);

            if (part.Length > 1 && part[0] == '0' || int.Parse(part) > 255)
            {
                continue;
            }

            path.Add(part);
            RestoreIpAddresses(s, start + i, path, result);
            path.RemoveAt(path.Count - 1);
        }
    }
}
