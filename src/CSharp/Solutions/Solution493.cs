namespace LeetCode.Solutions;

public class Solution493
{
    /// <summary>
    /// 493. Reverse Pairs - Hard
    /// <a href="https://leetcode.com/problems/reverse-pairs">See the problem</a>
    /// </summary>
    public int ReversePairs(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }
         
        return MergeSortAndCount(nums, 0, nums.Length - 1);
    }

    private int MergeSortAndCount(int[] nums, int left, int right)
    {
        if (left >= right) return 0;

        var mid = left + (right - left) / 2;
        var count = MergeSortAndCount(nums, left, mid) + MergeSortAndCount(nums, mid + 1, right);

        // Count the reverse pairs
        int j = mid + 1;
        for (int i = left; i <= mid; i++)
        {
            while (j <= right && nums[i] > 2L * nums[j])
            {
                j++;
            }
            count += j - (mid + 1);
        }

        // Merge the two halves
        Merge(nums, left, mid, right);

        return count;
    }

    private void Merge(int[] nums, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0;

        while (i <= mid && j <= right)
        {
            if (nums[i] <= nums[j])
            {
                temp[k++] = nums[i++];
            }
            else
            {
                temp[k++] = nums[j++];
            }
        }

        while (i <= mid)
        {
            temp[k++] = nums[i++];
        }

        while (j <= right)
        {
            temp[k++] = nums[j++];
        }

        for (i = left; i <= right; i++)
        {
            nums[i] = temp[i - left];
        }
    }
}
