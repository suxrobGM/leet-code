namespace LeetCode.Solutions;

public class Solution326
{
    /// <summary>
    /// 326. Power of Three - Easy
    /// <a href="https://leetcode.com/problems/power-of-three">See the problem</a>
    /// </summary>
    public bool IsPowerOfThree(int n)
    {
        return n > 0 && 1162261467 % n == 0;
    }
}
