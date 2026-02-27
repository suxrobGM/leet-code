namespace LeetCode.Solutions;

public class Solution2044
{
    /// <summary>
    /// 2044. Count Number of Maximum Bitwise-OR Subsets - Medium
    /// <a href="https://leetcode.com/problems/count-number-of-maximum-bitwise-or-subsets">See the problem</a>
    /// </summary>
    public int CountMaxOrSubsets(int[] nums)
    {
        var max = 0;
        var count = 0;

        for (var i = 0; i < 1 << nums.Length; i++)
        {
            var or = 0;
            for (var j = 0; j < nums.Length; j++)
            {
                if ((i & (1 << j)) > 0)
                    or |= nums[j];
            }

            if (or > max)
            {
                max = or;
                count = 1;
            }
            else if (or == max)
                count++;
        }

        return count;
    }
}
