namespace LeetCode.Solutions;

public class Solution315
{
    /// <summary>
    /// 315. Count of Smaller Numbers After Self - Hard
    /// <a href="https://leetcode.com/problems/count-of-smaller-numbers-after-self">See the problem</a>
    /// </summary>
    public IList<int> CountSmaller(int[] nums)
    {
        var n = nums.Length;
        var result = new int[n];
        var sorted = new List<int>();

        for (var i = n - 1; i >= 0; i--)
        {
            var index = BinarySearch(sorted, nums[i]);
            result[i] = index;
            sorted.Insert(index, nums[i]);
        }

        return result;
    }

    private int BinarySearch(List<int> sorted, int target)
    {
        var left = 0;
        var right = sorted.Count;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (sorted[mid] < target)
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
