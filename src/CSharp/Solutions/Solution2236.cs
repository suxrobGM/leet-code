using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2236
{
    /// <summary>
    /// 2236. Root Equals Sum of Children - Easy
    /// <a href="https://leetcode.com/problems/root-equals-sum-of-children">See the problem</a>
    /// </summary>
    public bool CheckTree(TreeNode root)
    {
        return root.val == root.left.val + root.right.val;
    }
}
