namespace LeetCode.Solutions;

public class Solution2064
{
    /// <summary>
    /// 2064. Minimized Maximum of Products Distributed to Any Store - Medium
    /// <a href="https://leetcode.com/problems/minimized-maximum-of-products-distributed-to-any-store">See the problem</a>
    /// </summary>
    public int MinimizedMaximum(int n, int[] quantities)
    {
        var left = 1;
        var right = quantities.Max();

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            var count = 0;

            foreach (var quantity in quantities)
            {
                count += (quantity + mid - 1) / mid; // Equivalent to Math.Ceiling((double)quantity / mid)
            }

            if (count > n)
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
