using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1662
{
    /// <summary>
    /// 1662. Check If Two String Arrays are Equivalent - Easy
    /// <a href="https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent">See the problem</a>
    /// </summary>
    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        return string.Join("", word1) == string.Join("", word2);
    }
}
