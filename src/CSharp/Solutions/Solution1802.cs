using System.Text;

namespace LeetCode.Solutions;

public class Solution1802
{
    /// <summary>
    /// 1802. Maximum Value at a Given Index in a Bounded Array - Medium
    /// <a href="https://leetcode.com/problems/maximum-value-at-a-given-index-in-a-bounded-array">See the problem</a>
    /// </summary>
    public int MaxValue(int n, int index, int maxSum)
    {
        int left = 1, right = maxSum, ans = 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (CanBuild(n, index, maxSum, mid))
            {
                ans = mid;
                left = mid + 1; // try bigger
            }
            else
            {
                right = mid - 1; // too big
            }
        }

        return ans;
    }

    private bool CanBuild(int n, int index, int maxSum, int peak)
    {
        long total = peak; // add center

        // left side
        int leftLen = index;
        if (peak > leftLen)
        {
            total += (long)leftLen * peak - (long)leftLen * (leftLen + 1) / 2;
        }
        else
        {
            total += (long)(peak - 1) * peak / 2 + (leftLen - (peak - 1));
        }

        // right side
        int rightLen = n - index - 1;
        if (peak > rightLen)
        {
            total += (long)rightLen * peak - (long)rightLen * (rightLen + 1) / 2;
        }
        else
        {
            total += (long)(peak - 1) * peak / 2 + (rightLen - (peak - 1));
        }

        return total <= maxSum;
    }
}

