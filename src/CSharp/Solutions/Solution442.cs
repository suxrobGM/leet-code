namespace LeetCode.Solutions;

public class Solution442
{
    /// <summary>
    /// 442. Find All Duplicates in an Array - Medium
    /// <a href="https://leetcode.com/problems/find-all-duplicates-in-an-array">See the problem</a>
    /// </summary>
    public IList<int> FindDuplicates(int[] nums)
    {
        var result = new List<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var index = Math.Abs(nums[i]) - 1;

            if (nums[index] < 0)
            {
                result.Add(index + 1);
            }
            else
            {
                nums[index] = -nums[index];
            }
        }

        return result;
    }
}
