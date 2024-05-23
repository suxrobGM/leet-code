using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution112
{
    /// <summary>
    /// 112. Path Sum - Easy
    /// <a href="https://leetcode.com/problems/path-sum">See the problem</a>
    /// </summary>
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null)
        {
            return false;
        }
        
        if (root.left == null && root.right == null)
        {
            return targetSum == root.val;
        }
        
        return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);
    }
}
