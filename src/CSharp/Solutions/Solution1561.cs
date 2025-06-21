using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1561
{
    /// <summary>
    /// 1561. Maximum Number of Coins You Can Get - Medium
    /// <a href="https://leetcode.com/problems/maximum-number-of-coins-you-can-get">See the problem</a>
    /// </summary>
    public int MaxCoins(int[] piles)
    {
        Array.Sort(piles);
        int n = piles.Length;
        int maxCoins = 0;

        // We take every second pile from the end, starting from the second last pile
        for (int i = n - 2; i >= n / 3; i -= 2)
        {
            maxCoins += piles[i];
        }

        return maxCoins;
    }
}
