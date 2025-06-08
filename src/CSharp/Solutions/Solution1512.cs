using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1512
{
    /// <summary>
    /// 1512. Number of Good Pairs - Easy
    /// <a href="https://leetcode.com/problems/number-of-good-pairs">See the problem</a>
    /// </summary>
    public int NumIdenticalPairs(int[] nums)
    {
        // Create a dictionary to count occurrences of each number
        var countMap = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (countMap.ContainsKey(num))
            {
                countMap[num]++;
            }
            else
            {
                countMap[num] = 1;
            }
        }

        // Calculate the number of good pairs
        int goodPairs = 0;
        foreach (var count in countMap.Values)
        {
            if (count > 1)
            {
                // If there are 'count' occurrences, the number of good pairs is count choose 2
                goodPairs += count * (count - 1) / 2;
            }
        }

        return goodPairs;
    }
}
