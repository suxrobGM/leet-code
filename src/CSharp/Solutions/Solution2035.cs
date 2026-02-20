namespace LeetCode.Solutions;

public class Solution2035
{
    /// <summary>
    /// 2035. Partition Array Into Two Arrays to Minimize Sum Difference - Hard
    /// <a href="https://leetcode.com/problems/partition-array-into-two-arrays-to-minimize-sum-difference">See the problem</a>
    /// </summary>
    public int MinimumDifference(int[] nums)
    {
        var n = nums.Length / 2;
        var total = nums.Sum();

        var left = GetSubsetSums(nums, 0, n);
        var right = GetSubsetSums(nums, n, n);

        foreach (var list in right)
            list.Sort();

        var result = int.MaxValue;
        for (var count = 0; count <= n; count++)
        {
            foreach (var leftSum in left[count])
            {
                var rightList = right[n - count];
                var target = total / 2 - leftSum;
                var idx = rightList.BinarySearch(target);
                if (idx < 0) idx = ~idx;

                if (idx < rightList.Count)
                    result = Math.Min(result, Math.Abs(total - 2 * (leftSum + rightList[idx])));
                if (idx > 0)
                    result = Math.Min(result, Math.Abs(total - 2 * (leftSum + rightList[idx - 1])));
            }
        }

        return result;
    }

    private static List<int>[] GetSubsetSums(int[] nums, int start, int n)
    {
        var result = new List<int>[n + 1];
        for (var i = 0; i <= n; i++)
            result[i] = [];

        for (var mask = 0; mask < (1 << n); mask++)
        {
            var sum = 0;
            var bits = 0;
            for (var i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    sum += nums[start + i];
                    bits++;
                }
            }

            result[bits].Add(sum);
        }

        return result;
    }
}
