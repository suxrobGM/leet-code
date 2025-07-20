using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1646
{
    /// <summary>
    /// 1646. Get Maximum in Generated Array - Easy
    /// <a href="https://leetcode.com/problems/get-maximum-in-generated-array">See the problem</a>
    /// </summary>
    public int GetMaximumGenerated(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        int[] nums = new int[n + 1];
        nums[0] = 0;
        nums[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            if (i % 2 == 0)
            {
                nums[i] = nums[i / 2];
            }
            else
            {
                nums[i] = nums[i / 2] + nums[i / 2 + 1];
            }
        }

        int max = 0;
        for (int i = 0; i <= n; i++)
        {
            if (nums[i] > max)
            {
                max = nums[i];
            }
        }

        return max;
    }
}
