using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution330
{
    /// <summary>
    /// 330. Patching Array - Hard
    /// <a href="https://leetcode.com/problems/patching-array">See the problem</a>
    /// </summary>
    public int MinPatches(int[] nums, int n)
    {
        var patches = 0;
        var i = 0;
        var miss = 1L;

        while (miss <= n)
        {
            if (i < nums.Length && nums[i] <= miss)
            {
                miss += nums[i++];
            }
            else
            {
                miss += miss;
                patches++;
            }
        }

        return patches;
    }
}
