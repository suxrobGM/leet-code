using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution113
{
    /// <summary>
    /// https://leetcode.com/problems/path-sum-ii - Medium
    /// <a href="https://leetcode.com/problems/path-sum-ii">See the problem</a>
    /// </summary>
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        var result = new List<IList<int>>();
        var path = new List<int>();
        PathSum(root, targetSum, path, result);
        return result;
    }
    
    private void PathSum(TreeNode root, int targetSum, List<int> path, List<IList<int>> result)
    {
        if (root == null)
        {
            return;
        }
        
        path.Add(root.val);
        
        if (root.left == null && root.right == null && targetSum == root.val)
        {
            result.Add(new List<int>(path));
        }
        else
        {
            PathSum(root.left, targetSum - root.val, path, result);
            PathSum(root.right, targetSum - root.val, path, result);
        }
        
        path.RemoveAt(path.Count - 1);
    }
}
