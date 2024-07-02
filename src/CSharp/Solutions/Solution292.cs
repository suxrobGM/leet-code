namespace LeetCode.Solutions;

public class Solution292
{
    /// <summary>
    /// 292. Nim Game - Easy
    /// <a href="https://leetcode.com/problems/nim-game">See the problem</a>
    /// </summary>
    public bool CanWinNim(int n)
    {
        return n % 4 != 0;
    }
}
