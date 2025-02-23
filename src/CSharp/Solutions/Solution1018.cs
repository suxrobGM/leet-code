using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1018
{
    /// <summary>
    /// 1018. Binary Prefix Divisible By 5 - Easy
    /// <a href="https://leetcode.com/problems/binary-prefix-divisible-by-5</a>
    /// </summary>
    public IList<bool> PrefixesDivBy5(int[] nums)
    {
        var result = new List<bool>();
        var remainder = 0;
        foreach (var num in nums)
        {
            remainder = (remainder * 2 + num) % 5;
            result.Add(remainder == 0);
        }

        return result;
    }
}
