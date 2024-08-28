using System.Text;

namespace LeetCode.Solutions;

public class Solution506
{
    /// <summary>
    /// 506. Relative Ranks - Easy
    /// <a href="https://leetcode.com/problems/relative-ranks">See the problem</a>
    /// </summary>
    public string[] FindRelativeRanks(int[] score)
    {
        var sortedScore = score.OrderByDescending(x => x).ToArray();
        var result = new string[score.Length];

        for (var i = 0; i < score.Length; i++)
        {
            var index = Array.IndexOf(sortedScore, score[i]);
            result[i] = index switch
            {
                0 => "Gold Medal",
                1 => "Silver Medal",
                2 => "Bronze Medal",
                _ => (index + 1).ToString()
            };
        }

        return result;
    }
}
