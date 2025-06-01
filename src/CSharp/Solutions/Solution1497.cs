using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1497
{
    /// <summary>
    /// 1497. Check If Array Pairs Are Divisible by k - Medium
    /// <a href="https://leetcode.com/problems/check-if-array-pairs-are-divisible-by-k">See the problem</a>
    /// </summary>
    public bool CanArrange(int[] arr, int k)
    {
        if (arr.Length % 2 != 0)
            return false; // If the array length is odd, we cannot form pairs

        var remainderCount = new int[k];

        foreach (var num in arr)
        {
            int remainder = ((num % k) + k) % k; // Handle negative numbers
            remainderCount[remainder]++;
        }

        for (int i = 1; i <= k / 2; i++)
        {
            if (remainderCount[i] != remainderCount[k - i])
                return false;
        }

        // Check the special case for remainder 0
        return remainderCount[0] % 2 == 0;
    }
}
