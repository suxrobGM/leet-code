using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution129
{
    /// <summary>
    /// 129. Sum Root to Leaf Numbers - Medium
    /// <a href="https://leetcode.com/problems/sum-root-to-leaf-numbers">See the problem</a>
    /// </summary>
    public int SumNumbers(TreeNode root)
    {
        return DFS(root, 0);
    }
    
    private int DFS(TreeNode node, int currentSum)
    {
        if (node == null)
        {
            return 0;
        }
        
        currentSum = currentSum * 10 + node.val;
        
        if (node.left == null && node.right == null)
        {
            return currentSum;
        }
        
        return DFS(node.left, currentSum) + DFS(node.right, currentSum);
    }
}
