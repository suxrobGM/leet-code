using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1750
{
    /// <summary>
    /// 1750. Minimum Length of String After Deleting Similar Ends - Medium
    /// <a href="https://leetcode.com/problems/minimum-length-of-string-after-deleting-similar-ends">See the problem</a>
    /// </summary>
    public int MinimumLength(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right && s[left] == s[right])
        {
            char currentChar = s[left];
            while (left <= right && s[left] == currentChar) left++;
            while (left <= right && s[right] == currentChar) right--;
        }

        return right - left + 1;
    }
}

