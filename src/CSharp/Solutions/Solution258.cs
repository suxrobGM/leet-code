using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution258
{
    /// <summary>
    /// 258. Add Digits - Easy
    /// <a href="https://leetcode.com/problems/add-digits">See the problem</a>
    /// </summary>
    public int AddDigits(int num)
    {
        return num == 0 ? 0 : num % 9 == 0 ? 9 : num % 9;
    }
}
