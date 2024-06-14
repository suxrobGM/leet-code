using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution179
{
    /// <summary>
    /// 179. Largest Number - Medium
    /// <a href="https://leetcode.com/problems/largest-number">See the problem</a>
    /// </summary>
    public string LargestNumber(int[] nums)
    {
        var result = new StringBuilder();
        Array.Sort(nums, (a, b) =>
        {
            var strA = a.ToString();
            var strB = b.ToString();
            return string.CompareOrdinal(strB + strA, strA + strB);
        });
        
        foreach (var num in nums)
        {
            result.Append(num);
        }
        
        return result[0] == '0' ? "0" : result.ToString();
    }
}
