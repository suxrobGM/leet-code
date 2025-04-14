using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1248
{
    /// <summary>
    /// 1248. Count Number of Nice Subarrays - Medium
    /// <a href="https://leetcode.com/problems/count-number-of-nice-subarrays">See the problem</a>
    /// </summary>
    public int NumberOfSubarrays(int[] nums, int k)
    {
        var countMap = new Dictionary<int, int>();
        countMap[0] = 1; // Base case: zero odd numbers seen initially

        int oddCount = 0;
        int result = 0;

        foreach (var num in nums)
        {
            if (num % 2 != 0)
                oddCount++;

            if (countMap.ContainsKey(oddCount - k))
                result += countMap[oddCount - k];

            if (!countMap.ContainsKey(oddCount))
                countMap[oddCount] = 0;

            countMap[oddCount]++;
        }

        return result;
    }
}
