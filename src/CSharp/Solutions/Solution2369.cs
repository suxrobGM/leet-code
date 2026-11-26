namespace LeetCode.Solutions;

public class Solution2369
{
    /// <summary>
    /// 2369. Check if There is a Valid Partition For The Array - Medium
    /// <a href="https://leetcode.com/problems/check-if-there-is-a-valid-partition-for-the-array">See the problem</a>
    /// </summary>
    public bool ValidPartition(int[] nums)
    {
        // At each length, these track the validity of prefixes shorter by 3, 2, and 1.
        bool threeBack = false;
        bool twoBack = true;
        bool oneBack = false;

        for (int length = 2; length <= nums.Length; length++)
        {
            int last = nums[length - 1];
            int previous = nums[length - 2];
            bool valid = twoBack && previous == last;

            if (length >= 3 && threeBack)
            {
                int first = nums[length - 3];
                bool equal = first == previous && previous == last;
                bool consecutive = first + 1 == previous && previous + 1 == last;
                valid |= equal || consecutive;
            }

            threeBack = twoBack;
            twoBack = oneBack;
            oneBack = valid;
        }

        return oneBack;
    }
}
