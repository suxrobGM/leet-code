using System.Text;

namespace LeetCode.Solutions;

public class Solution1090
{
    /// <summary>
    /// 1090. Largest Values From Labels - Medium
    /// <a href="https://leetcode.com/problems/largest-values-from-labels">See the problem</a>
    /// </summary>
    public int LargestValsFromLabels(int[] values, int[] labels, int numWanted, int useLimit)
    {
        var n = values.Length;
        var items = new List<(int value, int label)>(n);

        for (var i = 0; i < n; i++)
        {
            items.Add((values[i], labels[i]));
        }

        items.Sort((a, b) => b.value - a.value);

        var labelCount = new Dictionary<int, int>();
        var result = 0;
        var count = 0;

        foreach (var (value, label) in items)
        {
            if (count == numWanted)
            {
                break;
            }

            if (!labelCount.ContainsKey(label))
            {
                labelCount[label] = 0;
            }

            if (labelCount[label] < useLimit)
            {
                result += value;
                labelCount[label]++;
                count++;
            }
        }

        return result;
    }
}
