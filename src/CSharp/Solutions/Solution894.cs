using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution894
{
    private Dictionary<int, List<TreeNode>> memo = [];

    /// <summary>
    /// 894. All Possible Full Binary Trees - Medium
    /// <a href="https://leetcode.com/problems/all-possible-full-binary-trees">See the problem</a>
    /// </summary>
    public IList<TreeNode> AllPossibleFBT(int n)
    {
        if (n % 2 == 0)
        {
            return []; // Full binary trees must have an odd number of nodes
        }

        if (memo.ContainsKey(n))
        {
            return memo[n];
        }

        var result = new List<TreeNode>();

        if (n == 1)
        {
            result.Add(new TreeNode(0));
        }
        else
        {
            for (int leftNodes = 1; leftNodes < n; leftNodes += 2)
            {
                int rightNodes = n - 1 - leftNodes;
                foreach (var left in AllPossibleFBT(leftNodes))
                {
                    foreach (var right in AllPossibleFBT(rightNodes))
                    {
                        result.Add(new TreeNode(0, CloneTree(left), CloneTree(right)));
                    }
                }
            }
        }

        memo[n] = result;
        return result;
    }

    private TreeNode CloneTree(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }
        return new TreeNode(root.val, CloneTree(root.left), CloneTree(root.right));
    }
}
