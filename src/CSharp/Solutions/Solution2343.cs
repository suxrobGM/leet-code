namespace LeetCode.Solutions;

public class Solution2343
{
    /// <summary>
    /// 2343. Query Kth Smallest Trimmed Number - Medium
    /// <a href="https://leetcode.com/problems/query-kth-smallest-trimmed-number">See the problem</a>
    /// </summary>
    public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
    {
        int[] answer = new int[queries.Length];
        int[] order = Enumerable.Range(0, nums.Length).ToArray();
        int[] buffer = new int[nums.Length];
        int[] queryOrder = Enumerable.Range(0, queries.Length)
            .OrderBy(i => queries[i][1]).ToArray();
        int trim = 0;

        foreach (int queryIndex in queryOrder)
        {
            while (trim < queries[queryIndex][1])
            {
                int position = nums[0].Length - ++trim;
                int[] counts = new int[10];
                foreach (int index in order)
                    counts[nums[index][position] - '0']++;

                for (int digit = 1; digit < counts.Length; digit++)
                    counts[digit] += counts[digit - 1];

                // Stable sorting preserves the suffix order and breaks ties by index.
                for (int i = order.Length - 1; i >= 0; i--)
                {
                    int index = order[i];
                    int digit = nums[index][position] - '0';
                    buffer[--counts[digit]] = index;
                }

                (order, buffer) = (buffer, order);
            }

            answer[queryIndex] = order[queries[queryIndex][0] - 1];
        }

        return answer;
    }
}
