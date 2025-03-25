using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1137
{
    /// <summary>
    /// 1137. N-th Tribonacci Number - Easy
    /// <a href="https://leetcode.com/problems/n-th-tribonacci-number">See the problem</a>
    /// </summary>
    public int Tribonacci(int n)
    {
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;

        var tribonacci = new int[n + 1];
        tribonacci[0] = 0;
        tribonacci[1] = 1;
        tribonacci[2] = 1;

        for (int i = 3; i <= n; i++)
        {
            tribonacci[i] = tribonacci[i - 1] + tribonacci[i - 2] + tribonacci[i - 3];
        }

        return tribonacci[n];
    }
}
