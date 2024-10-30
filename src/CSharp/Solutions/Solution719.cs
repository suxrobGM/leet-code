using System.Text;

namespace LeetCode.Solutions;

public class Solution719
{
    /// <summary>
    /// 719. Find K-th Smallest Pair Distance - Hard
    /// <a href="https://leetcode.com/problems/find-k-th-smallest-pair-distance">See the problem</a>
    /// </summary>
    public int SmallestDistancePair(int[] nums, int k)
    {
        Array.Sort(nums);  // Step 1: Sort the array
        int left = 0, right = nums[nums.Length - 1] - nums[0];

        // Step 2: Binary search on distance
        while (left < right)
        {
            var mid = left + (right - left) / 2;

            // Step 3: Count pairs with distance <= mid
            var count = CountPairs(nums, mid);

            if (count >= k)
            {
                right = mid;  // Try for a smaller distance
            }
            else
            {
                left = mid + 1;  // Try for a larger distance
            }
        }

        return left;
    }

    // Helper function to count pairs with distance <= maxDist
    private int CountPairs(int[] nums, int maxDist)
    {
        var count = 0;
        var j = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            while (j < nums.Length && nums[j] - nums[i] <= maxDist)
            {
                j++;
            }
            count += j - i - 1;
        }

        return count;
    }
}
