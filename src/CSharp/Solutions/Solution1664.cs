using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1664
{
    /// <summary>
    /// 1664. Ways to Make a Fair Array - Medium
    /// <a href="https://leetcode.com/problems/ways-to-make-a-fair-array">See the problem</a>
    /// </summary>
    public int WaysToMakeFair(int[] nums)
    {
        int n = nums.Length;
        int[] leftOdd = new int[n + 1];
        int[] leftEven = new int[n + 1];
        int[] rightOdd = new int[n + 1];
        int[] rightEven = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                leftEven[i + 1] = leftEven[i] + nums[i];
                leftOdd[i + 1] = leftOdd[i];
            }
            else
            {
                leftOdd[i + 1] = leftOdd[i] + nums[i];
                leftEven[i + 1] = leftEven[i];
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            if (i % 2 == 0)
            {
                rightEven[i] = rightEven[i + 1] + nums[i];
                rightOdd[i] = rightOdd[i + 1];
            }
            else
            {
                rightOdd[i] = rightOdd[i + 1] + nums[i];
                rightEven[i] = rightEven[i + 1];
            }
        }

        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (leftOdd[i] + rightEven[i + 1] == leftEven[i] + rightOdd[i + 1])
            {
                count++;
            }
        }

        return count;
    }
}
