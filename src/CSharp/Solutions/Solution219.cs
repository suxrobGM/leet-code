namespace LeetCode.Solutions;

public class Solution219
{
    /// <summary>
    /// 219. Contains Duplicate II
    /// <a href="https://leetcode.com/problems/contains-duplicate-ii">See the problem</a>
    /// </summary>
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var seen = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (seen.ContainsKey(num) && Math.Abs(i - seen[num]) <= k)
            {
                return true;
            }

            seen[num] = i;
        }
        return false;
    }
}
