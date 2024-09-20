using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution563
{
    /// <summary>
    /// 563. Binary Tree Tilt - Easy
    /// <a href="https://leetcode.com/problems/binary-tree-tilt">See the problem</a>
    /// </summary>
    public int FindTilt(TreeNode root)
    {
        var tilt = 0;
        _ = PostOrder(root, ref tilt);
        return tilt;
    }

    private int PostOrder(TreeNode node, ref int tilt)
    {
        if (node == null)
        {
            return 0;
        }

        var left = PostOrder(node.left, ref tilt);
        var right = PostOrder(node.right, ref tilt);
        tilt += Math.Abs(left - right);
        return left + right + node.val;
    }
}
