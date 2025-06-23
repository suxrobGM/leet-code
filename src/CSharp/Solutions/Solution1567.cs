using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1567
{
    /// <summary>
    /// 1567. Maximum Length of Subarray With Positive Product - Medium
    /// <a href="https://leetcode.com/problems/maximum-length-of-subarray-with-positive-product">See the problem</a>
    /// </summary>
    public int GetMaxLen(int[] nums)
    {
        int maxLength = 0;
        int currentLength = 0;
        int negativeCount = 0;
        int firstNegativeIndex = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                // Reset on zero
                currentLength = 0;
                negativeCount = 0;
                firstNegativeIndex = -1;
            }
            else
            {
                currentLength++;
                if (nums[i] < 0)
                {
                    negativeCount++;
                    if (firstNegativeIndex == -1)
                    {
                        firstNegativeIndex = i;
                    }
                }

                if (negativeCount % 2 == 0)
                {
                    maxLength = Math.Max(maxLength, currentLength);
                }
                else
                {
                    maxLength = Math.Max(maxLength, i - firstNegativeIndex);
                }
            }
        }

        return maxLength;
    }
}
