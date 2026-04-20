using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2106
{
    /// <summary>
    /// 2106. Maximum Fruits Harvested After at Most K Steps - Hard
    /// <a href="https://leetcode.com/problems/maximum-fruits-harvested-after-at-most-k-steps">See the problem</a>
    /// </summary>
    public int MaxTotalFruits(int[][] fruits, int startPos, int k)
    {
        var n = fruits.Length;
        var best = 0;
        var sum = 0;
        var i = 0;

        for (var j = 0; j < n; j++)
        {
            sum += fruits[j][1];

            while (i <= j && Cost(fruits[i][0], fruits[j][0], startPos) > k)
            {
                sum -= fruits[i][1];
                i++;
            }

            if (i <= j)
            {
                best = Math.Max(best, sum);
            }
        }

        return best;
    }

    private static int Cost(int left, int right, int start)
    {
        return right - left + Math.Min(Math.Abs(start - left), Math.Abs(start - right));
    }
}
