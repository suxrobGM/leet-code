namespace LeetCode.Solutions;

public class Solution2363
{
    /// <summary>
    /// 2363. Merge Similar Items - Easy
    /// <a href="https://leetcode.com/problems/merge-similar-items">See the problem</a>
    /// </summary>
    public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
    {
        const int maxValue = 1000;
        int[] totalWeights = new int[maxValue + 1];

        foreach (int[] item in items1)
            totalWeights[item[0]] += item[1];

        foreach (int[] item in items2)
            totalWeights[item[0]] += item[1];

        var mergedItems = new List<IList<int>>();
        for (int value = 1; value <= maxValue; value++)
        {
            if (totalWeights[value] > 0)
                mergedItems.Add([value, totalWeights[value]]);
        }

        return mergedItems;
    }
}
