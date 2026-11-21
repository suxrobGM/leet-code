namespace LeetCode.Solutions;

public class Solution2364
{
    /// <summary>
    /// 2364. Count Number of Bad Pairs - Medium
    /// <a href="https://leetcode.com/problems/count-number-of-bad-pairs">See the problem</a>
    /// </summary>
    public long CountBadPairs(int[] nums)
    {
        var differenceCounts = new Dictionary<int, int>();
        long badPairs = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int difference = nums[i] - i;
            // Earlier indices with the same difference form good pairs with i.
            differenceCounts.TryGetValue(difference, out int goodPairs);
            badPairs += i - goodPairs;
            differenceCounts[difference] = goodPairs + 1;
        }

        return badPairs;
    }
}
