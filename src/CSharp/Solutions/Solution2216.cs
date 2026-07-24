namespace LeetCode.Solutions;

public class Solution2216
{
    /// <summary>
    /// 2216. Minimum Deletions to Make Array Beautiful - Medium
    /// <a href="https://leetcode.com/problems/minimum-deletions-to-make-array-beautiful">See the problem</a>
    /// </summary>
    public int MinDeletion(int[] nums)
    {
        int deletions = 0;
        int n = nums.Length;

        for (int i = 0; i < n - 1; i++)
        {
            if ((i - deletions) % 2 == 0 && nums[i] == nums[i + 1])
            {
                deletions++;
            }
        }

        if ((n - deletions) % 2 == 1)
        {
            deletions++;
        }

        return deletions;
    }
}
