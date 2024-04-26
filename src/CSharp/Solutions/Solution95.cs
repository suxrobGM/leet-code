using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution95
{
    /// <summary>
    /// 95. Unique Binary Search Trees II - Medium
    /// <a href="https://leetcode.com/problems/unique-binary-search-trees-ii">See the problem</a>
    /// </summary>
    public IList<TreeNode> GenerateTrees(int n)
    {
        if (n == 0)
        {
            return new List<TreeNode>();
        }

        return GenerateTrees(1, n);
    }
    
    private IList<TreeNode> GenerateTrees(int start, int end)
    {
        var result = new List<TreeNode>();

        if (start > end)
        {
            result.Add(null);
            return result;
        }

        for (var i = start; i <= end; i++)
        {
            var leftTrees = GenerateTrees(start, i - 1);
            var rightTrees = GenerateTrees(i + 1, end);

            foreach (var left in leftTrees)
            {
                foreach (var right in rightTrees)
                {
                    var root = new TreeNode(i)
                    {
                        left = left,
                        right = right
                    };

                    result.Add(root);
                }
            }
        }

        return result;
    }
}
