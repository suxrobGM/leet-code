namespace LeetCode.Solutions;

public class Solution2200
{
    /// <summary>
    /// 2200. Find All K-Distant Indices in an Array - Easy
    /// <a href="https://leetcode.com/problems/find-all-k-distant-indices-in-an-array">See the problem</a>
    /// </summary>
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        var indices = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == key)
            {
                // Check all indices within distance k
                for (int j = Math.Max(0, i - k); j <= Math.Min(nums.Length - 1, i + k); j++)
                {
                    if (!indices.Contains(j))
                    {
                        indices.Add(j);
                    }
                }
            }
        }

        return indices;
    }
}
