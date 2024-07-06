namespace LeetCode.Solutions;

public class Solution321
{
    /// <summary>
    /// 321. Create Maximum Number - Hard
    /// <a href="https://leetcode.com/problems/create-maximum-number">See the problem</a>
    /// </summary>
    public int[] MaxNumber(int[] nums1, int[] nums2, int k)
    {
        var result = new int[k];
        for (var i = Math.Max(0, k - nums2.Length); i <= Math.Min(k, nums1.Length); i++)
        {
            var candidate = Merge(MaxArray(nums1, i), MaxArray(nums2, k - i), k);
            if (IsGreater(candidate, 0, result, 0))
            {
                result = candidate;
            }
        }
        return result;
    }

    private int[] MaxArray(int[] nums, int k)
    {
        var result = new int[k];
        var n = nums.Length;
        for (var i = 0; i < n; i++)
        {
            while (n - i + result.Length > k && result.Length > 0 && result[^1] < nums[i])
            {
                result = result[..^1];
            }
            if (result.Length < k)
            {
                result = [.. result, nums[i]];
            }
        }
        return result;
    }

    private int[] Merge(int[] nums1, int[] nums2, int k)
    {
        var result = new int[k];
        var i = 0;
        var j = 0;
        for (var r = 0; r < k; r++)
        {
            result[r] = IsGreater(nums1, i, nums2, j) ? nums1[i++] : nums2[j++];
        }
        return result;
    }

    private bool IsGreater(int[] nums1, int i, int[] nums2, int j)
    {
        while (i < nums1.Length && j < nums2.Length && nums1[i] == nums2[j])
        {
            i++;
            j++;
        }
        return j == nums2.Length || (i < nums1.Length && nums1[i] > nums2[j]);
    }
}
