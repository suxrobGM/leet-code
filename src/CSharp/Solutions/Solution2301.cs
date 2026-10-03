using System.Text;

namespace LeetCode.Solutions;

public class Solution2301
{
    /// <summary>
    /// 2301. Match Substring After Replacement - Hard
    /// <a href="https://leetcode.com/problems/match-substring-after-replacement">See the problem</a>
    /// </summary>
    public bool MatchReplacement(string s, string sub, char[][] mappings)
    {
        var canMap = new bool[128, 128];

        foreach (var mapping in mappings)
        {
            canMap[mapping[0], mapping[1]] = true;
        }

        for (var i = 0; i + sub.Length <= s.Length; i++)
        {
            var j = 0;

            while (j < sub.Length && (s[i + j] == sub[j] || canMap[sub[j], s[i + j]]))
            {
                j++;
            }

            if (j == sub.Length)
            {
                return true;
            }
        }

        return false;
    }
}
