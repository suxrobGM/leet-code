namespace LeetCode.Solutions;

public class Solution1438
{
    /// <summary>
    /// 1438. Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit - Medium
    /// <a href="https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit">See the problem</a>
    /// </summary>
    public int LongestSubarray(int[] nums, int limit)
    {
        int left = 0, right = 0, maxLength = 0;
        var minDeque = new LinkedList<int>();
        var maxDeque = new LinkedList<int>();

        while (right < nums.Length)
        {
            while (minDeque.Count > 0 && nums[minDeque.Last.Value] >= nums[right])
                minDeque.RemoveLast();
            while (maxDeque.Count > 0 && nums[maxDeque.Last.Value] <= nums[right])
                maxDeque.RemoveLast();

            minDeque.AddLast(right);
            maxDeque.AddLast(right);

            while (nums[maxDeque.First.Value] - nums[minDeque.First.Value] > limit)
            {
                if (minDeque.First.Value == left)
                    minDeque.RemoveFirst();
                if (maxDeque.First.Value == left)
                    maxDeque.RemoveFirst();
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
            right++;
        }

        return maxLength;
    }
}
