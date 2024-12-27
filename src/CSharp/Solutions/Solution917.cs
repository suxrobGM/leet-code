using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution917
{
    /// <summary>
    /// 917. Reverse Only Letters - Easy
    /// <a href="https://leetcode.com/problems/reverse-only-letters">See the problem</a>
    /// </summary>
    public string ReverseOnlyLetters(string s)
    {
        var chars = s.ToCharArray();
        var left = 0;
        var right = s.Length - 1;
        while (left < right)
        {
            if (!char.IsLetter(chars[left]))
            {
                left++;
            }
            else if (!char.IsLetter(chars[right]))
            {
                right--;
            }
            else
            {
                (chars[left], chars[right]) = (chars[right], chars[left]);
                left++;
                right--;
            }
        }

        return new string(chars);
    }
}
