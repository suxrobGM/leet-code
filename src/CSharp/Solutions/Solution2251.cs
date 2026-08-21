namespace LeetCode.Solutions;

public class Solution2251
{
    /// <summary>
    /// 2251. Number of Flowers in Full Bloom - Hard
    /// <a href="https://leetcode.com/problems/number-of-flowers-in-full-bloom">See the problem</a>
    /// </summary>
    public int[] FullBloomFlowers(int[][] flowers, int[] people)
    {
        // A flower is in bloom at time t when it started at or before t and has
        // not ended before t, so the answer is (starts <= t) - (ends < t).
        // Starts and ends can be sorted independently and binary searched
        var starts = new int[flowers.Length];
        var ends = new int[flowers.Length];

        for (var i = 0; i < flowers.Length; i++)
        {
            starts[i] = flowers[i][0];
            ends[i] = flowers[i][1];
        }

        Array.Sort(starts);
        Array.Sort(ends);

        var answer = new int[people.Length];

        for (var i = 0; i < people.Length; i++)
        {
            var time = people[i];
            answer[i] = UpperBound(starts, time) - LowerBound(ends, time);
        }

        return answer;
    }

    /// <summary>
    /// Counts the values that are strictly less than the target.
    /// </summary>
    private static int LowerBound(int[] values, int target)
    {
        int low = 0, high = values.Length;

        while (low < high)
        {
            var mid = low + (high - low) / 2;

            if (values[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }

    /// <summary>
    /// Counts the values that are less than or equal to the target.
    /// </summary>
    private static int UpperBound(int[] values, int target)
    {
        int low = 0, high = values.Length;

        while (low < high)
        {
            var mid = low + (high - low) / 2;

            if (values[mid] <= target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }
}
