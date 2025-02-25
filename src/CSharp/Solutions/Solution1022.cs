using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1022
{
    /// <summary>
    /// 1022. Sum of Root To Leaf Binary Numbers - Easy
    /// <a href="https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers</a>
    /// </summary>
    public int SumRootToLeaf(TreeNode root)
    {
        return SumRootToLeaf(root, 0);
    }

    private int SumRootToLeaf(TreeNode root, int sum)
    {
        if (root == null)
        {
            return 0;
        }

        sum = sum * 2 + root.val;

        if (root.left == null && root.right == null)
        {
            return sum;
        }

        return SumRootToLeaf(root.left, sum) + SumRootToLeaf(root.right, sum);
    }
}
