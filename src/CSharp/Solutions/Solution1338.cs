using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1338
{
    /// <summary>
    /// 1338. Reduce Array Size to The Half - Medium
    /// <a href="https://leetcode.com/problems/reduce-array-size-to-the-half">See the problem</a>
    /// </summary>
    public int MinSetSize(int[] arr)
    {
        var frequency = new Dictionary<int, int>();
        foreach (var num in arr)
        {
            if (frequency.ContainsKey(num))
                frequency[num]++;
            else
                frequency[num] = 1;
        }

        var sortedFrequencies = frequency.Values.OrderByDescending(x => x).ToList();
        int halfSize = arr.Length / 2;
        int count = 0, size = 0;

        foreach (var freq in sortedFrequencies)
        {
            size += freq;
            count++;
            if (size >= halfSize)
                break;
        }

        return count;
    }
}
