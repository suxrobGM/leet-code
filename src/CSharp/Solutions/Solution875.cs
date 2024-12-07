using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution875
{
    /// <summary>
    /// 875. Koko Eating Bananas - Medium
    /// <a href="https://leetcode.com/problems/koko-eating-bananas">See the problem</a>
    /// </summary>
    public int MinEatingSpeed(int[] piles, int h)
    {
        int left = 1;
        int right = piles.Max();

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            int hours = 0;

            foreach (var pile in piles)
            {
                hours += (pile + mid - 1) / mid;
            }

            if (hours > h)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}
