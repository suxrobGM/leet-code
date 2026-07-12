namespace LeetCode.Solutions;

public class Solution2202
{
    /// <summary>
    /// 2202. Maximize the Topmost Element After K Moves - Medium
    /// <a href="https://leetcode.com/problems/maximize-the-topmost-element-after-k-moves">See the problem</a>
    /// </summary>
    public int MaximumTop(int[] nums, int k)
    {
        var n = nums.Length;

        if (k == 0) return nums[0];

        // A single element can only be toggled off and on, so an odd k leaves the pile empty
        if (n == 1) return k % 2 == 0 ? nums[0] : -1;

        // The first element must be removed and there is no move left to put anything back
        if (k == 1) return nums[1];

        // Remove up to k - 1 elements, then use the last move to push the largest of them back
        var best = -1;
        var removable = Math.Min(k - 1, n);

        for (int i = 0; i < removable; i++)
        {
            best = Math.Max(best, nums[i]);
        }

        // Alternatively, spend every move removing, which exposes nums[k]
        if (k < n)
        {
            best = Math.Max(best, nums[k]);
        }

        return best;
    }
}
