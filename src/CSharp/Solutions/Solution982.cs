using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution982
{
    /// <summary>
    /// 982. Triples with Bitwise AND Equal To Zero - Hard
    /// <a href="https://leetcode.com/problems/triples-with-bitwise-and-equal-to-zero">See the problem</a>
    /// </summary>
    public int CountTriplets(int[] nums)
    {
        var andPairFrequency = new Dictionary<int, int>();
        int n = nums.Length;

        // Step 1: Compute all (nums[i] & nums[j]) and store frequency
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int andResult = nums[i] & nums[j];
                if (!andPairFrequency.ContainsKey(andResult))
                    andPairFrequency[andResult] = 0;

                andPairFrequency[andResult]++;
            }
        }

        // Step 2: Count valid triplets (nums[i] & nums[j] & nums[k] == 0)
        int count = 0;
        foreach (var kvp in andPairFrequency)
        {
            int andValue = kvp.Key;
            int freq = kvp.Value;

            foreach (int num in nums)
            {
                if ((andValue & num) == 0)
                {
                    count += freq; // Every valid (i, j) pair contributes `freq` triplets
                }
            }
        }

        return count;
    }
}
