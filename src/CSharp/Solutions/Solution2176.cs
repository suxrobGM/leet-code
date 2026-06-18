namespace LeetCode.Solutions;

public class Solution2176
{
    /// <summary>
    /// 2176. Count Equal and Divisible Pairs in an Array - Easy
    /// <a href="https://leetcode.com/problems/count-equal-and-divisible-pairs-in-an-array">See the problem</a>
    /// </summary>
    public int CountPairs(int[] nums, int k)
    {
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j] && (i * j) % k == 0)
                {
                    count++;
                }
            }
        }
        return count;
    }
}
