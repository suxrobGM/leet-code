using System.Text;

namespace LeetCode.Solutions;

public class Solution77
{
    /// <summary>
    /// 77. Combinations - Medium
    /// <a href="https://leetcode.com/problems/combinations">See the problem</a>
    /// </summary>
    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();
        var current = new List<int>();

        Backtrack(1);
        return result;

        void Backtrack(int start)
        {
            if (current.Count == k)
            {
                result.Add(new List<int>(current));
                return;
            }

            for (var i = start; i <= n; i++)
            {
                current.Add(i);
                Backtrack(i + 1);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
