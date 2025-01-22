using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution951
{
    /// <summary>
    /// 951. Flip Equivalent Binary Trees - Medium
    /// <a href="https://leetcode.com/problems/flip-equivalent-binary-trees">See the problem</a>
    /// </summary>
    public bool FlipEquiv(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null)
        {
            return true;
        }

        if (root1 == null || root2 == null || root1.val != root2.val)
        {
            return false;
        }

        return (FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right)) ||
               (FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left));
    }
}
