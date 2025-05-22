using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1461
{
    /// <summary>
    /// 1461. Check If a String Contains All Binary Codes of Size K - Medium
    /// <a href="https://leetcode.com/problems/check-if-a-string-contains-all-binary-codes-of-size-k">See the problem</a>
    /// </summary>
    public bool HasAllCodes(string s, int k)
    {
        if (s.Length < k)
            return false;

        var seen = new HashSet<string>();
        int totalCodes = 1 << k; // 2^k

        for (int i = 0; i <= s.Length - k; i++)
        {
            string code = s.Substring(i, k);
            seen.Add(code);
            if (seen.Count == totalCodes)
                return true;
        }

        return false;
    }
}
