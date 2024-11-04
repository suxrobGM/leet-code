using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution763
{
    /// <summary>
    /// 763. Partition Labels - Medium
    /// <a href="https://leetcode.com/problems/partition-labels">See the problem</a>
    /// </summary>
    public IList<int> PartitionLabels(string s)
    {
        var last = new int[26];
        for (var i = 0; i < s.Length; i++)
        {
            last[s[i] - 'a'] = i;
        }

        var result = new List<int>();
        var start = 0;
        var end = 0;

        for (var i = 0; i < s.Length; i++)
        {
            end = Math.Max(end, last[s[i] - 'a']);
            if (i == end)
            {
                result.Add(end - start + 1);
                start = end + 1;
            }
        }

        return result;
    }
}
