namespace LeetCode.Solutions;

public class Solution47
{
    /// <summary>
    /// 47. Permutations II - Medium
    /// <a href="https://leetcode.com/problems/permutations-ii">See the problem</a>
    /// </summary>
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var permutations = new List<IList<int>>();
        var uniquePermutations = new HashSet<string>();
        GeneratePermutations(nums, 0, permutations, uniquePermutations);
        return permutations.ToList();
    }
    
    private void GeneratePermutations(int[] nums, int start, List<IList<int>> result, HashSet<string> uniquePermutations)
    {
        if (start == nums.Length - 1)
        {
            var permutation = string.Join(",", nums);

            if (uniquePermutations.Add(permutation))
            {
                result.Add(nums.ToList());
            }
            
            return;
        }

        for (var i = start; i < nums.Length; i++)
        {
            // swap the current element with the start element
            (nums[i], nums[start]) = (nums[start], nums[i]);
            
            // recursive call to generate permutations for the rest of the array
            GeneratePermutations(nums, start + 1, result, uniquePermutations);
            
            // backtracking, restore the array to its original state after the recursive call
            (nums[i], nums[start]) = (nums[start], nums[i]); 
        }
    }
}
