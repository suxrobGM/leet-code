namespace LeetCode.Solutions;

public class Solution2190
{
    /// <summary>
    /// 2190. Most Frequent Number Following Key In an Array - Easy
    /// <a href="https://leetcode.com/problems/most-frequent-number-following-key-in-an-array">See the problem</a>
    /// </summary>
    public int MostFrequent(int[] nums, int key)
    {
        // Count how often each value directly follows an occurrence of key.
        var counts = new Dictionary<int, int>();
        int best = nums[1], bestCount = 0;

        for (int i = 0; i + 1 < nums.Length; i++)
        {
            if (nums[i] != key)
            {
                continue;
            }

            int target = nums[i + 1];
            int count = counts.GetValueOrDefault(target) + 1;
            counts[target] = count;

            if (count > bestCount)
            {
                bestCount = count;
                best = target;
            }
        }

        return best;
    }
}
