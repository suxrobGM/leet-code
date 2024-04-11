namespace LeetCode.Solutions;

public class Solution78
{
    /// <summary>
    /// 78. Subsets - Medium
    /// <a href="https://leetcode.com/problems/subsets">See the problem</a>
    /// </summary>
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        var current = new List<int>();

        Backtrack(0);
        return result;

        void Backtrack(int start)
        {
            result.Add(new List<int>(current));

            for (var i = start; i < nums.Length; i++)
            {
                current.Add(nums[i]);
                Backtrack(i + 1);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
