namespace LeetCode.Solutions;

public class Solution220
{
    /// <summary>
    /// 220. Contains Duplicate III - Hard
    /// <a href="https://leetcode.com/problems/contains-duplicate-iii">See the problem</a>
    /// </summary>
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
    {
        var n = nums.Length;
        var sorted = new SortedSet<long>();

        for (var i = 0; i < n; i++)
        {
            if (i > indexDiff)
            {
                sorted.Remove(nums[i - indexDiff - 1]);
            }

            var lower = (long)nums[i] - valueDiff;
            var upper = (long)nums[i] + valueDiff;

            if (sorted.GetViewBetween(lower, upper).Count != 0)
            {
                return true;
            }

            sorted.Add(nums[i]);
        }

        return false;
    }
}
