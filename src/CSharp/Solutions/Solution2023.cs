namespace LeetCode.Solutions;

public class Solution2023
{
    /// <summary>
    /// 2023. Number of Pairs of Strings With Concatenation Equal to Target - Medium
    /// <a href="https://leetcode.com/problems/number-of-pairs-of-strings-with-concatenation-equal-to-target">See the problem</a>
    /// </summary>
    public int NumOfPairs(string[] nums, string target)
    {
        var count = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < nums.Length; j++)
            {
                if (i != j && nums[i] + nums[j] == target)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
