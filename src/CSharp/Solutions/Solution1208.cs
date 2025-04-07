using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1208
{
    /// <summary>
    /// 1208. Get Equal Substrings Within Budget - Medium
    /// <a href="https://leetcode.com/problems/get-equal-substrings-within-budget">See the problem</a>
    /// </summary>
    public int EqualSubstring(string s, string t, int maxCost)
    {
        int n = s.Length;
        int left = 0, right = 0, totalCost = 0, maxLength = 0;

        while (right < n)
        {
            totalCost += Math.Abs(s[right] - t[right]);
            while (totalCost > maxCost)
            {
                totalCost -= Math.Abs(s[left] - t[left]);
                left++;
            }
            maxLength = Math.Max(maxLength, right - left + 1);
            right++;
        }

        return maxLength;
    }
}
