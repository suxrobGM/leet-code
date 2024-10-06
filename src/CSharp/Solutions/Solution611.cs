using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution611
{
    /// <summary>
    /// 611. Valid Triangle Number - Medium
    /// <a href="https://leetcode.com/problems/valid-triangle-number">See the problem</a>
    /// </summary>
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);
        var count = 0;
        for (var i = 0; i < nums.Length - 2; i++)
        {
            for (var j = i + 1; j < nums.Length - 1; j++)
            {
                var k = j + 1;
                while (k < nums.Length && nums[i] + nums[j] > nums[k])
                {
                    k++;
                }
                count += k - j - 1;
            }
        }
        return count;
    }
}
