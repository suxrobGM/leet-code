namespace LeetCode.Solutions;

public class Solution1985
{
    /// <summary>
    /// 1985. Find the Kth Largest Integer in the Array - Medium
    /// <a href="https://leetcode.com/problems/find-the-kth-largest-integer-in-the-array">See the problem</a>
    /// </summary>
    public string KthLargestNumber(string[] nums, int k)
    {
        Array.Sort(nums, (a, b) =>
        {
            if (a.Length != b.Length)
            {
                return a.Length.CompareTo(b.Length);
            }
            return string.CompareOrdinal(a, b);
        });

        return nums[nums.Length - k];
    }
}
