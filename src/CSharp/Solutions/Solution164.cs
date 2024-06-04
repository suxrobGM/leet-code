namespace LeetCode.Solutions;

public class Solution164
{
    /// <summary>
    /// 164. Maximum Gap - Medium
    /// <a href="https://leetcode.com/problems/maximum-gap">See the problem</a>
    /// </summary>
    public int MaximumGap(int[] nums)
    {
        if (nums.Length < 2)
        {
            return 0;
        }

        var min = nums[0];
        var max = nums[0];

        foreach (var num in nums)
        {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }

        var bucketSize = Math.Max(1, (max - min) / (nums.Length - 1));
        var bucketCount = (max - min) / bucketSize + 1;

        var bucketMin = new int[bucketCount];
        var bucketMax = new int[bucketCount];
        var bucketUsed = new bool[bucketCount];

        foreach (var num in nums)
        {
            var bucketIndex = (num - min) / bucketSize;
            bucketMin[bucketIndex] = bucketUsed[bucketIndex] ? Math.Min(bucketMin[bucketIndex], num) : num;
            bucketMax[bucketIndex] = bucketUsed[bucketIndex] ? Math.Max(bucketMax[bucketIndex], num) : num;
            bucketUsed[bucketIndex] = true;
        }

        var maxGap = 0;
        var prevBucketMax = min;

        for (var i = 0; i < bucketCount; i++)
        {
            if (!bucketUsed[i])
            {
                continue;
            }

            maxGap = Math.Max(maxGap, bucketMin[i] - prevBucketMax);
            prevBucketMax = bucketMax[i];
        }

        return maxGap;
    }
}
