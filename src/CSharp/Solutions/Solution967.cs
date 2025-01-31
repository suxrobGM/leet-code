using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution967
{
    /// <summary>
    /// 967. Numbers With Same Consecutive Differences - Medium
    /// <a href="https://leetcode.com/problems/numbers-with-same-consecutive-differences">See the problem</a>
    /// </summary>
    public int[] NumsSameConsecDiff(int n, int k)
    {
        var result = new List<int>();
        for (var i = 1; i <= 9; i++)
        {
            NumsSameConsecDiff(n, k, i, 1, result);
        }

        return result.ToArray();
    }

    private void NumsSameConsecDiff(int n, int k, int num, int len, List<int> result)
    {
        if (len == n)
        {
            result.Add(num);
            return;
        }

        var lastDigit = num % 10;
        if (lastDigit + k <= 9)
        {
            NumsSameConsecDiff(n, k, num * 10 + lastDigit + k, len + 1, result);
        }

        if (k != 0 && lastDigit - k >= 0)
        {
            NumsSameConsecDiff(n, k, num * 10 + lastDigit - k, len + 1, result);
        }
    }
}
