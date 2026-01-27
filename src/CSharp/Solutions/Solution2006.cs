namespace LeetCode.Solutions;

public class Solution2006
{
    /// <summary>
    /// 2006. Count Number of Pairs With Absolute Difference K - Easy
    /// <a href="https://leetcode.com/problems/count-number-of-pairs-with-absolute-difference-k">See the problem</a>
    /// </summary>
    public int CountKDifference(int[] nums, int k)
    {
        int count = 0;
        var freq = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (freq.ContainsKey(num - k))
            {
                count += freq[num - k];
            }
            if (freq.ContainsKey(num + k))
            {
                count += freq[num + k];
            }

            if (freq.ContainsKey(num))
            {
                freq[num]++;
            }
            else
            {
                freq[num] = 1;
            }
        }

        return count;
    }
}
