using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution508
{
    /// <summary>
    /// 508. Most Frequent Subtree Sum - Medium
    /// <a href="https://leetcode.com/problems/most-frequent-subtree-sum">See the problem</a>
    /// </summary>
    public int[] FindFrequentTreeSum(TreeNode root)
    {
        var sumCount = new Dictionary<int, int>();
        var maxCount = 0;

        Traverse(root, sumCount, ref maxCount);

        var result = new List<int>();

        foreach (var (sum, count) in sumCount)
        {
            if (count == maxCount)
            {
                result.Add(sum);
            }
        }

        return result.ToArray();
    }

    private int Traverse(TreeNode node, Dictionary<int, int> sumCount, ref int maxCount)
    {
        if (node == null)
        {
            return 0;
        }

        var sum = node.val + Traverse(node.left, sumCount, ref maxCount) + Traverse(node.right, sumCount, ref maxCount);

        sumCount[sum] = sumCount.GetValueOrDefault(sum, 0) + 1;
        maxCount = Math.Max(maxCount, sumCount[sum]);

        return sum;
    }
}
