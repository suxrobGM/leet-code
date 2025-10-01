using System.Text;

namespace LeetCode.Solutions;

public class Solution1848
{
    /// <summary>
    /// 1848. Minimum Distance to the Target Element - Easy
    /// <a href="https://leetcode.com/problems/minimum-distance-to-the-target-element">See the problem</a>
    /// </summary>
    public int GetMinDistance(int[] nums, int target, int start)
    {
        int ans = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                ans = Math.Min(ans, Math.Abs(i - start));
            }
        }
        return ans;
    }
}
