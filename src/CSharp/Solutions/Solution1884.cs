using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1884
{
    /// <summary>
    /// 1884. Egg Drop With 2 Eggs and N Floors - Medium
    /// <a href="https://leetcode.com/problems/egg-drop-with-2-eggs-and-n-floors">See the problem</a>
    /// </summary>
    public int TwoEggDrop(int n)
    {
        // Let k be the number of drops in the worst case.
        // The optimal strategy is to drop the first egg from floor k,
        // then from floor k + (k - 1), then from floor k + (k - 1) + (k - 2), and so on.
        // This way, if the first egg breaks at some floor, we can use the second egg
        // to check all the floors below it in the worst case.
        //
        // We need to find the smallest k such that:
        // k + (k - 1) + (k - 2) + ... + 1 >= n
        // This is equivalent to k * (k + 1) / 2 >= n
        //
        // Solving for k gives us:
        // k^2 + k - 2n >= 0
        // Using the quadratic formula, we find:
        // k >= (-1 + sqrt(1 + 8n)) / 2

        return (int)Math.Ceiling((-1 + Math.Sqrt(1 + 8 * n)) / 2);
    }
}
