namespace LeetCode.Solutions;

public class Solution491
{
    /// <summary>
    /// 491. Increasing Subsequences - Medium
    /// <a href="https://leetcode.com/problems/increasing-subsequences">See the problem</a>
    /// </summary>
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        var result = new List<IList<int>>();
        Helper(nums, 0, new List<int>(), result);
        return result;
    }

    private void Helper(int[] nums, int start, List<int> current, List<IList<int>> result)
    {
        if (current.Count > 1)
        {
            result.Add(new List<int>(current));
        }

        var used = new HashSet<int>();
        for (var i = start; i < nums.Length; i++)
        {
            if (used.Contains(nums[i])) continue;
            if (current.Count == 0 || nums[i] >= current[current.Count - 1])
            {
                used.Add(nums[i]);
                current.Add(nums[i]);
                Helper(nums, i + 1, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
