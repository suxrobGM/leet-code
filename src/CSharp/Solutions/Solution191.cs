namespace LeetCode.Solutions;

public class Solution191
{
    /// <summary>
    /// 191. Number of 1 Bits - Easy
    /// <a href="https://leetcode.com/problems/number-of-1-bits">See the problem</a>
    /// </summary>
    public int HammingWeight(int n)
    {
        var count = 0;
        while (n != 0)
        {
            count++;
            n &= n - 1;
        }
        return count;
    }
}
