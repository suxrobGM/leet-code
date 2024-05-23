using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution110
{
    /// <summary>
    /// 110. Balanced Binary Tree - Easy
    /// <a href="https://leetcode.com/problems/balanced-binary-tree">See the problem</a>
    /// </summary>
    public bool IsBalanced(TreeNode root)
    {
        return Height(root) != -1;
    }
    
    private int Height(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        
        var leftHeight = Height(node.left);
        if (leftHeight == -1)
        {
            return -1;
        }
        
        var rightHeight = Height(node.right);
        if (rightHeight == -1)
        {
            return -1;
        }
        
        if (Math.Abs(leftHeight - rightHeight) > 1)
        {
            return -1;
        }
        
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
