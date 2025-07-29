using System.Text;


namespace LeetCode.Solutions;

public class Solution1673
{
    /// <summary>
    /// 1673. Find the Most Competitive Subsequence - Medium
    /// <a href="https://leetcode.com/problems/find-the-most-competitive-subsequence">See the problem</a>
    /// </summary>
    public int[] MostCompetitive(int[] nums, int k)
    {
        var stack = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            while (stack.Count > 0 &&
                   stack[stack.Count - 1] > nums[i] &&
                   stack.Count + nums.Length - i - 1 >= k)
            {
                stack.RemoveAt(stack.Count - 1);
            }

            if (stack.Count < k)
                stack.Add(nums[i]);
        }

        return stack.ToArray();
    }
}
