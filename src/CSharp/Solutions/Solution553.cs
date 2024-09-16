using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution553
{
    /// <summary>
    /// 553. Optimal Division - Medium
    /// <a href="https://leetcode.com/problems/optimal-division">See the problem</a>
    /// </summary>
    public string OptimalDivision(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0].ToString();
        }

        if (nums.Length == 2)
        {
            return $"{nums[0]}/{nums[1]}";
        }

        var sb = new StringBuilder();
        sb.Append(nums[0]);
        sb.Append("/(");
        for (int i = 1; i < nums.Length; i++)
        {
            sb.Append(nums[i]);
            sb.Append("/");
        }
        sb.Remove(sb.Length - 1, 1);
        sb.Append(")");

        return sb.ToString();
    }
}
