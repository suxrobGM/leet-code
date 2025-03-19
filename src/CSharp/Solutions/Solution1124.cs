using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1124
{
    /// <summary>
    /// 1124. Longest Well-Performing Interval - Medium
    /// <a href="https://leetcode.com/problems/longest-well-performing-interval">See the problem</a>
    /// </summary>
    public int LongestWPI(int[] hours)
    {
        var sum = 0;
        var max = 0;
        var map = new Dictionary<int, int>();

        for (var i = 0; i < hours.Length; i++)
        {
            sum += hours[i] > 8 ? 1 : -1;

            if (sum > 0)
            {
                max = i + 1;
            }
            else
            {
                if (!map.ContainsKey(sum))
                {
                    map[sum] = i;
                }

                if (map.ContainsKey(sum - 1))
                {
                    max = Math.Max(max, i - map[sum - 1]);
                }
            }
        }

        return max;
    }
}
