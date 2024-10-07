using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution617
{
    /// <summary>
    /// 617. Merge Two Binary Trees - Easy
    /// <a href="https://leetcode.com/problems/merge-two-binary-trees">See the problem</a>
    /// </summary>
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        if (root1 == null)
        {
            return root2;
        }
        if (root2 == null)
        {
            return root1;
        }
        root1.val += root2.val;
        root1.left = MergeTrees(root1.left, root2.left);
        root1.right = MergeTrees(root1.right, root2.right);
        return root1;
    }
}
