using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution525
{
    /// <summary>
    /// 525. Contiguous Array - Medium
    /// <a href="https://leetcode.com/problems/contiguous-array">See the problem</a>
    /// </summary>
    public int FindMaxLength(int[] nums)
    {
        // Dictionary to store (count, index)
        var countIndexMap = new Dictionary<int, int>();
        countIndexMap[0] = -1;  // Initialize with count 0 at index -1 to handle edge cases
        int maxLength = 0;
        int count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            count += nums[i] == 0 ? -1 : 1;

            if (countIndexMap.ContainsKey(count))
            {
                maxLength = Math.Max(maxLength, i - countIndexMap[count]);
            }
            else
            {
                countIndexMap[count] = i;
            }
        }

        return maxLength;
    }
}
