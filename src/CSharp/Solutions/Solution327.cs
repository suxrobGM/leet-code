namespace LeetCode.Solutions;

public class Solution327
{
    /// <summary>
    /// 327. Count of Range Sum - Hard
    /// <a href="https://leetcode.com/problems/count-of-range-sum">See the problem</a>
    /// </summary>
    public int CountRangeSum(int[] nums, int lower, int upper)
    {
        var n = nums.Length;
        var sum = new long[n + 1];
        for (var i = 0; i < n; i++)
        {
            sum[i + 1] = sum[i] + nums[i];
        }

        return CountWhileMergeSort(sum, 0, n + 1, lower, upper);
    }

    private int CountWhileMergeSort(long[] sum, int left, int right, int lower, int upper)
    {
        if (right - left <= 1)
        {
            return 0;
        }

        var mid = left + (right - left) / 2;
        var count = CountWhileMergeSort(sum, left, mid, lower, upper) + CountWhileMergeSort(sum, mid, right, lower, upper);

        var j = mid;
        var k = mid;
        var t = mid;
        var cache = new long[right - left];
        for (var i = left; i < mid; i++)
        {
            while (k < right && sum[k] - sum[i] < lower)
            {
                k++;
            }
            while (j < right && sum[j] - sum[i] <= upper)
            {
                j++;
            }
            while (t < right && sum[t] < sum[i])
            {
                cache[t - left] = sum[t++];
            }
            cache[i - left] = sum[i];
            count += j - k;
        }

        Array.Copy(cache, 0, sum, left, t - left);

        return count;
    }
}
