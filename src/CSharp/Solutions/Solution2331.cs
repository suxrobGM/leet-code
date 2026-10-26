namespace LeetCode.Solutions;

public class Solution2331
{
    /// <summary>
    /// 2331. Evaluate Boolean Binary Tree - Easy
    /// <a href="https://leetcode.com/problems/evaluate-boolean-binary-tree">See the problem</a>
    /// </summary>
    public bool EvaluateTree(TreeNode root)
    {
        return root.val switch
        {
            0 => false,
            1 => true,
            2 => EvaluateTree(root.left) || EvaluateTree(root.right),
            3 => EvaluateTree(root.left) && EvaluateTree(root.right),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
