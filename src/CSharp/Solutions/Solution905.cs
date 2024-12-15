using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution905
{
    /// <summary>
    /// 905. Sort Array By Parity - Easy
    /// <a href="https://leetcode.com/problems/sort-array-by-parity">See the problem</a>
    /// </summary>
    public int[] SortArrayByParity(int[] nums)
    {
        int n = nums.Length;
        int i = 0;
        int j = n - 1;

        while (i < j)
        {
            if (nums[i] % 2 == 1 && nums[j] % 2 == 0)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }

            if (nums[i] % 2 == 0)
            {
                i++;
            }

            if (nums[j] % 2 == 1)
            {
                j--;
            }
        }

        return nums;
    }
}
