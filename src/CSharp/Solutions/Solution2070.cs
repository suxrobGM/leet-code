namespace LeetCode.Solutions;

public class Solution2070
{
    /// <summary>
    /// 2070. Most Beautiful Item for Each Query - Medium
    /// <a href="https://leetcode.com/problems/walking-robot-simulation-ii">See the problem</a>
    /// </summary>
    public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        var sortedItems = items.OrderBy(i => i[0]).ToArray();
        var sortedQueries = queries.Select((q, i) => (q, i)).OrderBy(q => q.q).ToArray();

        var result = new int[queries.Length];
        var maxBeauty = 0;
        var itemIndex = 0;

        foreach (var (query, index) in sortedQueries)
        {
            while (itemIndex < sortedItems.Length && sortedItems[itemIndex][0] <= query)
            {
                maxBeauty = Math.Max(maxBeauty, sortedItems[itemIndex][1]);
                itemIndex++;
            }

            result[index] = maxBeauty;
        }

        return result;
    }
}
