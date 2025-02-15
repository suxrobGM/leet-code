using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution993
{
    /// <summary>
    /// 993. Cousins in Binary Tree - Easy
    /// <a href="https://leetcode.com/problems/cousins-in-binary-tree">See the problem</a>
    /// </summary>
    public bool IsCousins(TreeNode root, int x, int y)
    {
        var xParent = 0;
        var yParent = 0;
        var xDepth = 0;
        var yDepth = 0;

        void Dfs(TreeNode node, int parent, int depth)
        {
            if (node == null)
            {
                return;
            }

            if (node.val == x)
            {
                xParent = parent;
                xDepth = depth;
            }
            else if (node.val == y)
            {
                yParent = parent;
                yDepth = depth;
            }

            Dfs(node.left, node.val, depth + 1);
            Dfs(node.right, node.val, depth + 1);
        }

        Dfs(root, 0, 0);

        return xParent != yParent && xDepth == yDepth;
    }
}
