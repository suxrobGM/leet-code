using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution222
{
    /// <summary>
    /// 222. Count Complete Tree Nodes - Easy
    /// <a href="https://leetcode.com/problems/count-complete-tree-nodes">See the problem</a>
    /// </summary>
    public int CountNodes(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var leftHeight = GetHeight(root.left);
        var rightHeight = GetHeight(root.right);

        if (leftHeight == rightHeight)
        {
            return (1 << leftHeight) + CountNodes(root.right);
        }
        else
        {
            return (1 << rightHeight) + CountNodes(root.left);
        }
    }

    private int GetHeight(TreeNode node)
    {
        var height = 0;
        while (node != null)
        {
            height++;
            node = node.left;
        }
        return height;
    }
}
