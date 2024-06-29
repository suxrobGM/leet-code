using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution235
{
    /// <summary>
    /// 235. Lowest Common Ancestor of a Binary Search Tree - Medium
    /// <a href="https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree">See the problem</a>
    /// </summary>
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        while (root != null)
        {
            if (root.val < p.val && root.val < q.val)
            {
                root = root.right;
            }
            else if (root.val > p.val && root.val > q.val)
            {
                root = root.left;
            }
            else
            {
                return root;
            }
        }

        return null;
    }
}
