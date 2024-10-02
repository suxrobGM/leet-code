namespace LeetCode.Solutions;

public class Solution594
{
    /// <summary>
    /// 594. Longest Harmonious Subsequence - Easy
    /// <a href="https://leetcode.com/problems/longest-harmonious-subsequence">See the problem</a>
    /// </summary>
    public int FindLHS(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict[num] = 1;
            }
        }
        var result = 0;
        foreach (var key in dict.Keys)
        {
            if (dict.ContainsKey(key + 1))
            {
                result = Math.Max(result, dict[key] + dict[key + 1]);
            }
        }
        return result;
    }
}
