using System.Text;

namespace LeetCode.Solutions;

public class Solution1793
{
    /// <summary>
    /// 1793. Maximum Score of a Good Subarray - Hard
    /// <a href="https://leetcode.com/problems/maximum-score-of-a-good-subarray">See the problem</a>
    /// </summary>
    public int MaximumScore(int[] nums, int k)
    {
        int n = nums.Length;
        int i = k, j = k;
        int minVal = nums[k];
        int res = minVal;

        while (i > 0 || j < n - 1)
        {
            // expand towards the bigger neighbor
            if (i == 0)
            {
                j++;
            }
            else if (j == n - 1)
            {
                i--;
            }
            else if (nums[i - 1] >= nums[j + 1])
            {
                i--;
            }
            else
            {
                j++;
            }

            minVal = Math.Min(minVal, Math.Min(nums[i], nums[j]));
            res = Math.Max(res, minVal * (j - i + 1));
        }

        return res;
    }
}

