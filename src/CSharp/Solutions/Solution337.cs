using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution337
{
    /// <summary>
    /// 337. House Robber III - Medium
    /// <a href="https://leetcode.com/problems/house-robber-iii">See the problem</a>
    /// </summary>
    public int Rob(TreeNode root)
    {
        var result = RobSub(root);
        return Math.Max(result[0], result[1]);
    }

    private int[] RobSub(TreeNode root)
    {
        if (root == null)
        {
            return new int[2];
        }

        var left = RobSub(root.left);
        var right = RobSub(root.right);

        var result = new int[2];

        result[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
        result[1] = root.val + left[0] + right[0];

        return result;
    }
}
