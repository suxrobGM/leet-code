namespace LeetCode.Solutions;

public class Solution287
{
    /// <summary>
    /// 287. Find the Duplicate Number - Medium
    /// <a href="https://leetcode.com/problems/find-the-duplicate-number">See the problem</a>
    /// </summary>
    public int FindDuplicate(int[] nums)
    {
        var slow = nums[0];
        var fast = nums[0];

        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        slow = nums[0];

        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }
}
