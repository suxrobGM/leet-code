using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1207
{
    /// <summary>
    /// 1207. Unique Number of Occurrences - Easy
    /// <a href="https://leetcode.com/problems/unique-number-of-occurrences">See the problem</a>
    /// </summary>
    public bool UniqueOccurrences(int[] arr)
    {
        var frequency = new Dictionary<int, int>();
        foreach (var num in arr)
        {
            if (frequency.ContainsKey(num))
                frequency[num]++;
            else
                frequency[num] = 1;
        }

        var occurrences = new HashSet<int>();
        foreach (var count in frequency.Values)
        {
            if (!occurrences.Add(count))
                return false;
        }

        return true;
    }
}
