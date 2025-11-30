using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1925
{
    private const long MOD = 1_000_000_007;

    /// <summary>
    /// 1925. Count Square Sum Triples - Easy
    /// <a href="https://leetcode.com/problems/count-square-sum-triples">See the problem</a>
    /// </summary>
    public int CountTriples(int n)
    {
        int count = 0;

        for (int a = 1; a <= n; a++)
        {
            int a2 = a * a;
            for (int b = 1; b <= n; b++)
            {
                int c2 = a2 + b * b;
                int c = (int)Math.Sqrt(c2);

                // Check if c^2 == a^2 + b^2 and c is in range
                if (c * c == c2 && c <= n)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
