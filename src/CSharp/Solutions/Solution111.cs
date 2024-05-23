using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution111
{
    /// <summary>
    /// 111. Minimum Depth of Binary Tree - Easy
    /// <a href="https://leetcode.com/problems/minimum-depth-of-binary-tree">See the problem</a>
    /// </summary>
    public int MinDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        
        if (root.left == null && root.right == null)
        {
            return 1;
        }
        
        var minDepth = int.MaxValue;
        
        if (root.left != null)
        {
            minDepth = Math.Min(minDepth, MinDepth(root.left));
        }
        
        if (root.right != null)
        {
            minDepth = Math.Min(minDepth, MinDepth(root.right));
        }
        
        return minDepth + 1;
    }
}
