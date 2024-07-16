namespace LeetCode.Solutions;

public class Solution390
{
    /// <summary>
    /// 390. Elimination Game - Medium
    /// <a href="https://leetcode.com/problems/elimination-game">See the problem</a>
    /// </summary>
    public int LastRemaining(int n)
    {
        var leftToRight = true;
        var remaining = n;
        var step = 1;
        var head = 1;

        while (remaining > 1)
        {
            if (leftToRight || remaining % 2 == 1)
            {
                head += step;
            }

            remaining /= 2;
            step *= 2;
            leftToRight = !leftToRight;
        }

        return head;
    }
}
