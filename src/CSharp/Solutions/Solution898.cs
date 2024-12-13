using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution898
{
    /// <summary>
    /// 898. Bitwise ORs of Subarrays - Medium
    /// <a href="https://leetcode.com/problems/bitwise-ors-of-subarrays">See the problem</a>
    /// </summary>
    public int SubarrayBitwiseORs(int[] arr)
    {
        var result = new HashSet<int>();
        var previous = new HashSet<int>();

        foreach (var num in arr)
        {
            var current = new HashSet<int> { num };
            foreach (var prev in previous)
            {
                current.Add(num | prev);
            }
            result.UnionWith(current);
            previous = current;
        }

        return result.Count;
    }
}
