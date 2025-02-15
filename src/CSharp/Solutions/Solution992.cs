using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution992
{
    /// <summary>
    /// 992. Subarrays with K Different Integers - Hard
    /// <a href="https://leetcode.com/problems/subarrays-with-k-different-integers">See the problem</a>
    /// </summary>
    public int SubarraysWithKDistinct(int[] nums, int k)
    {
        return AtMostKDistinct(nums, k) - AtMostKDistinct(nums, k - 1);
    }

    private int AtMostKDistinct(int[] nums, int k)
    {
        var count = new Dictionary<int, int>();
        var result = 0;
        var left = 0;

        for (var right = 0; right < nums.Length; right++)
        {
            if (!count.ContainsKey(nums[right]))
            {
                count[nums[right]] = 0;
            }

            count[nums[right]]++;

            while (count.Count > k)
            {
                count[nums[left]]--;

                if (count[nums[left]] == 0)
                {
                    count.Remove(nums[left]);
                }

                left++;
            }

            result += right - left + 1;
        }

        return result;
    }
}
