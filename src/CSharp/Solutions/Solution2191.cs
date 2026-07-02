namespace LeetCode.Solutions;

public class Solution2191
{
    /// <summary>
    /// 2191. Sort the Jumbled Numbers - Medium
    /// <a href="https://leetcode.com/problems/sort-the-jumbled-numbers">See the problem</a>
    /// </summary>
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        return nums.OrderBy(x => x.ToString().Select(c => mapping[c - '0']).Aggregate((a, b) => a * 10 + b)).ToArray();
    }
}
