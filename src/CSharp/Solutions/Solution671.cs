using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution671
{
    /// <summary>
    /// 671. Second Minimum Node In a Binary Tree - Easy
    /// <a href="https://leetcode.com/problems/second-minimum-node-in-a-binary-tree">See the problem</a>
    /// </summary>
    public int FindSecondMinimumValue(TreeNode root)
    {
        var min = root.val;
        var result = long.MaxValue;

        void Traverse(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            if (node.val > min && node.val < result)
            {
                result = node.val;
            }

            Traverse(node.left);
            Traverse(node.right);
        }

        Traverse(root);

        return result == long.MaxValue ? -1 : (int)result;
    }
}
