using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1608
{
    /// <summary>
    /// 1608. Special Array With X Elements Greater Than or Equal X - Easy
    /// <a href="https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x">See the problem</a>
    /// </summary>
    public int SpecialArray(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;

        for (int x = 1; x <= n; x++)
        {
            int count = 0;
            foreach (int num in nums)
            {
                if (num >= x)
                    count++;
            }

            if (count == x)
                return x;
        }

        return -1;
    }
}
