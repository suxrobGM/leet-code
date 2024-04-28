using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution98
{
    /// <summary>
    /// 98. Validate Binary Search Tree - Medium
    /// <a href="https://leetcode.com/problems/validate-binary-search-tree">See the problem</a>
    /// </summary>
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBST(root, long.MinValue, long.MaxValue);
    }
    
    private bool IsValidBST(TreeNode node, long lower, long upper)
    {
        if (node is null)
        {
            return true;
        }
        
        if (node.val <= lower || node.val >= upper)
        {
            return false;
        }
        
        return IsValidBST(node.left, lower, node.val) && IsValidBST(node.right, node.val, upper);
    }
}
