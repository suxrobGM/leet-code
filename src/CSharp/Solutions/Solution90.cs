namespace LeetCode.Solutions;

public class Solution90
{
    /// <summary>
    /// 90. Subsets II - Medium
    /// <a href="https://leetcode.com/problems/subsets-ii">See the problem</a>
    /// </summary>
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        Array.Sort(nums); // Sort the numbers to handle duplicates
        var results = new List<IList<int>>();
        Backtrack(0, nums, [], results);
        return results;
    }

    private void Backtrack(int start, int[] nums, List<int> current, List<IList<int>> results)
    {
        results.Add(new List<int>(current)); // Add a copy of the current subset

        for (var i = start; i < nums.Length; i++)
        {
            // Skip duplicates
            if (i > start && nums[i] == nums[i - 1])
            {
                continue;
            }

            current.Add(nums[i]); // Include the current element
            Backtrack(i + 1, nums, current, results); // Recurse with the current element included
            current.RemoveAt(current.Count - 1); // Exclude the current element, backtrack
        }
    }
}
