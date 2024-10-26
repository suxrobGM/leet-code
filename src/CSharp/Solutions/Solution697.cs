using System.Text;

namespace LeetCode.Solutions;

public class Solution697
{
    /// <summary>
    /// 697. Degree of an Array - Easy
    /// <a href="https://leetcode.com/problems/degree-of-an-array">See the problem</a>
    /// </summary>
    public int FindShortestSubArray(int[] nums)
    {
        var frequencyMap = new Dictionary<int, int>();
        var firstOccurrence = new Dictionary<int, int>();
        var lastOccurrence = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            frequencyMap[num] = frequencyMap.GetValueOrDefault(num, 0) + 1;
            lastOccurrence[num] = i;
            if (!firstOccurrence.ContainsKey(num))
            {
                firstOccurrence[num] = i;
            }
        }

        var maxFrequency = frequencyMap.Values.Max();
        var minSubArrayLength = int.MaxValue;

        foreach (var num in frequencyMap.Keys)
        {
            if (frequencyMap[num] == maxFrequency)
            {
                minSubArrayLength = Math.Min(minSubArrayLength, lastOccurrence[num] - firstOccurrence[num] + 1);
            }
        }

        return minSubArrayLength;
    }
}
