using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1481
{
    /// <summary>
    /// 1481. Least Number of Unique Integers after K Removals - Medium
    /// <a href="https://leetcode.com/problems/least-number-of-unique-integers-after-k-removals">See the problem</a>
    /// </summary>
    public int FindLeastNumOfUniqueInts(int[] arr, int k)
    {
        var frequency = new Dictionary<int, int>();
        foreach (var num in arr)
        {
            if (frequency.ContainsKey(num))
                frequency[num]++;
            else
                frequency[num] = 1;
        }

        var sortedFrequencies = frequency.Values.OrderBy(f => f).ToList();
        int uniqueCount = sortedFrequencies.Count;

        for (int i = 0; i < sortedFrequencies.Count && k > 0; i++)
        {
            if (k >= sortedFrequencies[i])
            {
                k -= sortedFrequencies[i];
                uniqueCount--;
            }
            else
            {
                break;
            }
        }

        return uniqueCount;
    }
}
