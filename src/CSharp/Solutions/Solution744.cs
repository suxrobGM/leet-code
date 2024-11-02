using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution744
{
    /// <summary>
    /// 744. Find Smallest Letter Greater Than Target - Easy
    /// <a href="https://leetcode.com/problems/find-smallest-letter-greater-than-target">See the problem</a>
    /// </summary>
    public char NextGreatestLetter(char[] letters, char target)
    {
        var left = 0;
        var right = letters.Length;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (letters[mid] <= target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left == letters.Length ? letters[0] : letters[left];
    }
}
