namespace LeetCode.Solutions;

public class Solution2341
{
    /// <summary>
    /// 2341. Maximum Number of Pairs in Array - Easy
    /// <a href="https://leetcode.com/problems/maximum-number-of-pairs-in-array">See the problem</a>
    /// </summary>
    public int[] NumberOfPairs(int[] nums)
    {
        int[] counts = new int[101];
        foreach (int num in nums)
            counts[num]++;

        int pairs = 0;
        int leftovers = 0;
        foreach (int count in counts)
        {
            pairs += count / 2;
            leftovers += count % 2;
        }

        return [pairs, leftovers];
    }
}
