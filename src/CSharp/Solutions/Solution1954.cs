using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1954
{
    /// <summary>
    /// 1954. Minimum Garden Perimeter to Collect Enough Apples - Medium
    /// <a href="https://leetcode.com/problems/minimum-garden-perimeter-to-collect-enough-apples">See the problem</a>
    /// </summary>
    public long MinimumPerimeter(long neededApples)
    {
        // Binary search for the minimum n such that CountApples(n) >= neededApples
        long left = 0, right = 100000;

        while (left < right)
        {
            long mid = (left + right) / 2;

            if (CountApples(mid) < neededApples)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        // The square extends from -left to left, so perimeter is 8*left
        return 8 * left;
    }

    // For a square from (-n, -n) to (n, n), the total apples is:
    // 2 * n * (n + 1) * (2*n + 1)
    // 
    // Derivation:
    // Total = Σ(i=-n to n) Σ(j=-n to n) (|i| + |j|)
    //       = 2 * Σ(i=-n to n) |i| * (2n+1)
    //       = 2 * n * (n+1) * (2n+1)
    private long CountApples(long n)
    {
        return 2 * n * (n + 1) * (2 * n + 1);
    }
}
