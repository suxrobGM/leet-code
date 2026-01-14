namespace LeetCode.Solutions;

public class Solution1991
{
    /// <summary>
    /// 1991. Find the Middle Index in Array - Easy
    /// <a href="https://leetcode.com/problems/find-the-middle-index-in-array">See the problem</a>
    /// </summary>
    public int FindMiddleIndex(int[] nums)
    {
        int totalSum = 0;
        foreach (var num in nums)
        {
            totalSum += num;
        }

        int leftSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int rightSum = totalSum - leftSum - nums[i];
            if (leftSum == rightSum)
            {
                return i;
            }
            leftSum += nums[i];
        }

        return -1;
    }
}
