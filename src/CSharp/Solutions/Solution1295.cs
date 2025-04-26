using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1295
{
    /// <summary>
    /// 1295. Find Numbers with Even Number of Digits - Easy
    /// <a href="https://leetcode.com/problems/find-numbers-with-even-number-of-digits">See the problem</a>
    /// </summary>
    public int FindNumbers(int[] nums)
    {
        int count = 0;
        foreach (var num in nums)
        {
            if (num.ToString().Length % 2 == 0)
            {
                count++;
            }
        }
        return count;
    }
}
