using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution404
{
    /// <summary>
    /// 404. Sum of Left Leaves - Easy
    /// <a href="https://leetcode.com/problems/sum-of-left-leaves">See the problem</a>
    /// </summary>
    public int SumOfLeftLeaves(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var sum = 0;

        if (root.left != null && root.left.left == null && root.left.right == null)
        {
            sum += root.left.val;
        }

        sum += SumOfLeftLeaves(root.left);
        sum += SumOfLeftLeaves(root.right);

        return sum;
    }
}
