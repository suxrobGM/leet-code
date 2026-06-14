namespace LeetCode.Solutions;

public class Solution2170
{
    /// <summary>
    /// 2170. Minimum Operations to Make the Array Alternating - Medium
    /// <a href="https://leetcode.com/problems/minimum-operations-to-make-the-array-alternating">See the problem</a>
    /// </summary>
    public int MinimumOperations(int[] nums)
    {
        var n = nums.Length;
        if (n == 1) return 0;

        var evenCount = new Dictionary<int, int>();
        var oddCount = new Dictionary<int, int>();

        for (int i = 0; i < n; i += 2)
        {
            evenCount[nums[i]] = evenCount.GetValueOrDefault(nums[i]) + 1;
        }

        for (int i = 1; i < n; i += 2)
        {
            oddCount[nums[i]] = oddCount.GetValueOrDefault(nums[i]) + 1;
        }

        var evenMax = evenCount.OrderByDescending(x => x.Value).FirstOrDefault();
        var oddMax = oddCount.OrderByDescending(x => x.Value).FirstOrDefault();

        if (evenMax.Key != oddMax.Key)
        {
            return n - evenMax.Value - oddMax.Value;
        }

        var evenSecondMax = evenCount.OrderByDescending(x => x.Value).Skip(1).FirstOrDefault();
        var oddSecondMax = oddCount.OrderByDescending(x => x.Value).Skip(1).FirstOrDefault();

        return n - Math.Max(evenMax.Value + oddSecondMax.Value, evenSecondMax.Value + oddMax.Value);
    }
}
