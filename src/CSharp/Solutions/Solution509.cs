using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution509
{
    /// <summary>
    /// 509. Fibonacci Number - Easy
    /// <a href="https://leetcode.com/problems/fibonacci-number">See the problem</a>
    /// </summary>
    public int Fib(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }

        var a = 0;
        var b = 1;

        for (var i = 2; i <= n; i++)
        {
            var c = a + b;
            a = b;
            b = c;
        }

        return b;
    }
}
