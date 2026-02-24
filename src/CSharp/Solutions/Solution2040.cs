namespace LeetCode.Solutions;

public class Solution2040
{
    /// <summary>
    /// 2040. Kth Smallest Product of Two Sorted Arrays - Hard
    /// <a href="https://leetcode.com/problems/kth-smallest-product-of-two-sorted-arrays">See the problem</a>
    /// </summary>
    public long KthSmallestProduct(int[] nums1, int[] nums2, long k)
    {
        long lo = -10_000_000_000L, hi = 10_000_000_000L;

        while (lo < hi)
        {
            var mid = lo + (hi - lo) / 2;
            if (CountLessOrEqual(nums1, nums2, mid) >= k)
                hi = mid;
            else
                lo = mid + 1;
        }

        return lo;
    }

    private static long CountLessOrEqual(int[] nums1, int[] nums2, long target)
    {
        long count = 0;

        foreach (var a in nums1)
        {
            if (a > 0)
            {
                int lo = 0, hi = nums2.Length - 1, pos = -1;
                while (lo <= hi)
                {
                    var mid = lo + (hi - lo) / 2;
                    if ((long)a * nums2[mid] <= target)
                    {
                        pos = mid;
                        lo = mid + 1;
                    }
                    else
                        hi = mid - 1;
                }

                count += pos + 1;
            }
            else if (a < 0)
            {
                int lo = 0, hi = nums2.Length - 1, pos = nums2.Length;
                while (lo <= hi)
                {
                    var mid = lo + (hi - lo) / 2;
                    if ((long)a * nums2[mid] <= target)
                    {
                        pos = mid;
                        hi = mid - 1;
                    }
                    else
                        lo = mid + 1;
                }

                count += nums2.Length - pos;
            }
            else
            {
                if (target >= 0)
                    count += nums2.Length;
            }
        }

        return count;
    }
}
