namespace LeetCode.Solutions;

public class Solution440
{
    /// <summary>
    /// 440. K-th Smallest in Lexicographical Order - Hard
    /// <a href="https://leetcode.com/problems/k-th-smallest-in-lexicographical-order">See the problem</a>
    /// </summary>
    public int FindKthNumber(int n, int k)
    {
        var current = 1;
        k--;

        while (k > 0)
        {
            var steps = CalculateSteps(n, current, current + 1);

            if (steps <= k)
            {
                current++;
                k -= steps;
            }
            else
            {
                current *= 10;
                k--;
            }
        }

        return current;
    }

    private int CalculateSteps(int n, long n1, long n2)
    {
        var steps = 0;

        while (n1 <= n)
        {
            steps += (int)(Math.Min(n + 1, n2) - n1);
            n1 *= 10;
            n2 *= 10;
        }

        return steps;
    }
}
