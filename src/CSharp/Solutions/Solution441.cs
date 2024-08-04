namespace LeetCode.Solutions;

public class Solution441
{
    /// <summary>
    /// 441. Arranging Coins - Easy
    /// <a href="https://leetcode.com/problems/arranging-coins">See the problem</a>
    /// </summary>
    public int ArrangeCoins(int n)
    {
        int left = 0, right = n;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            long sum = (long)mid * (mid + 1) / 2;

            if (sum == n)
            {
                return mid;
            }
            else if (sum < n)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return right;
    }
}
