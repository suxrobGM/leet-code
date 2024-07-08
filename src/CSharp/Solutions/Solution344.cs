using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution344
{
    /// <summary>
    /// 344. Reverse String - Easy
    /// <a href="https://leetcode.com/problems/reverse-string">See the problem</a>
    /// </summary>
    public void ReverseString(char[] s)
    {
        var left = 0;
        var right = s.Length - 1;

        while (left < right)
        {
            (s[right], s[left]) = (s[left], s[right]);
            left++;
            right--;
        }
    }
}
