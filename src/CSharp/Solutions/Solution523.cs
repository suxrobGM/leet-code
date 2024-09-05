using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution523
{
    /// <summary>
    /// 523. Continuous Subarray Sum - Medium
    /// <a href="https://leetcode.com/problems/continuous-subarray-sum">See the problem</a>
    /// </summary>
    public bool CheckSubarraySum(int[] nums, int k)
    {
        // Dictionary to store (remainder, index)
        var remainderIndexMap = new Dictionary<int, int>();
        remainderIndexMap[0] = -1;  // Initialize with remainder 0 at index -1 to handle edge cases
        int prefixSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum += nums[i];

            // Calculate remainder of prefixSum divided by k
            int remainder = prefixSum % k;
            
            // Adjust for negative remainders to ensure positive index usage
            if (remainder < 0) remainder += k;

            // Check if this remainder has been seen before
            if (remainderIndexMap.ContainsKey(remainder))
            {
                // Ensure the subarray length is at least 2
                if (i - remainderIndexMap[remainder] > 1)
                {
                    return true;
                }
            }
            else
            {
                // Store the remainder with the corresponding index
                remainderIndexMap[remainder] = i;
            }
        }

        // If no valid subarray found
        return false;
    }
}
