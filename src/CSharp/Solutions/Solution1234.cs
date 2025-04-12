using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1234
{
    /// <summary>
    /// 1234. Replace the Substring for Balanced String - Medium
    /// <a href="https://leetcode.com/problems/replace-the-substring-for-balanced-string">See the problem</a>
    /// </summary>
    public int BalancedString(string s)
    {
        int n = s.Length;
        int target = n / 4;

        var count = new Dictionary<char, int> {
            { 'Q', 0 }, { 'W', 0 }, { 'E', 0 }, { 'R', 0 }
        };

        foreach (char c in s)
            count[c]++;

        // If already balanced
        if (IsBalanced(count, target))
            return 0;

        int minLen = n;
        int left = 0;

        for (int right = 0; right < n; right++)
        {
            count[s[right]]--;

            while (left <= right && IsBalanced(count, target))
            {
                minLen = Math.Min(minLen, right - left + 1);
                count[s[left]]++;
                left++;
            }
        }

        return minLen;
    }

    private bool IsBalanced(Dictionary<char, int> count, int target)
    {
        return count['Q'] <= target &&
               count['W'] <= target &&
               count['E'] <= target &&
               count['R'] <= target;
    }
}
