namespace LeetCode.Solutions;

public class Solution216
{
    /// <summary>
    /// 216. Combination Sum III - Medium
    /// <a href="https://leetcode.com/problems/combination-sum-iii">See the problem</a>
    /// </summary>
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        var result = new List<IList<int>>();
        var current = new List<int>();
        
        Backtrack(result, current, k, n, 1);
        
        return result;
    }

    private void Backtrack(List<IList<int>> result, List<int> current, int k, int n, int start)
    {
        if (n == 0 && k == 0)
        {
            result.Add(new List<int>(current));
            return;
        }
        
        if (n < 0 || k < 0)
        {
            return;
        }
        
        for (var i = start; i <= 9; i++)
        {
            current.Add(i);
            Backtrack(result, current, k - 1, n - i, i + 1);
            current.RemoveAt(current.Count - 1);
        }
    }
}
