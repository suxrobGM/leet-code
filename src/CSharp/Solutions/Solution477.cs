namespace LeetCode.Solutions;

public class Solution477
{
    /// <summary>
    /// 477. Total Hamming Distance - Medium
    /// <a href="https://leetcode.com/problems/total-hamming-distance">See the problem</a>
    /// </summary>
    public int TotalHammingDistance(int[] nums)
    {
        var total = 0;
        var n = nums.Length;

        for (var i = 0; i < 32; i++)
        {
            var count = 0;
            foreach (var num in nums)
            {
                count += (num >> i) & 1;
            }

            total += count * (n - count);
        }

        return total;
    }
}
