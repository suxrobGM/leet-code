using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1315
{
    /// <summary>
    /// 1315. Sum of Nodes with Even-Valued Grandparent - Medium
    /// <a href="https://leetcode.com/problems/sum-of-nodes-with-even-valued-grandparent">See the problem</a>
    /// </summary>
    public int SumEvenGrandparent(TreeNode root)
    {
        if (root == null) return 0;
        return SumEvenGrandparentHelper(root, null, null);
    }

    private int SumEvenGrandparentHelper(TreeNode node, TreeNode parent, TreeNode grandparent)
    {
        if (node == null) return 0;

        int sum = 0;
        if (grandparent != null && grandparent.val % 2 == 0)
        {
            sum += node.val;
        }

        sum += SumEvenGrandparentHelper(node.left, node, parent) + SumEvenGrandparentHelper(node.right, node, parent);
        return sum;
    }
}
