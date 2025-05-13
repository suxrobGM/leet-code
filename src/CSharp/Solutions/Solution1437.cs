namespace LeetCode.Solutions;

public class Solution1437
{
    /// <summary>
    /// 1437. Check If All 1's Are at Least Length K Places Away - Easy
    /// <a href="https://leetcode.com/problems/check-if-all-1s-are-at-least-length-k-places-away">See the problem</a>
    /// </summary>
    public bool KLengthApart(int[] nums, int k)
    {
        int lastOneIndex = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                if (lastOneIndex != -1 && i - lastOneIndex <= k)
                {
                    return false;
                }
                lastOneIndex = i;
            }
        }

        return true;
    }
}
