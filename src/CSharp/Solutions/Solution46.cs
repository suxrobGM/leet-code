namespace LeetCode.Solutions;

public class Solution46
{
    /// <summary>
    /// 46. Permutations - Medium
    /// <a href="https://leetcode.com/problems/permutations">See the problem</a>
    /// </summary>
    public IList<IList<int>> Permute(int[] nums)
    {
        var permutations = new List<IList<int>>();
        GeneratePermutations(nums, 0, permutations);
        return permutations;
    }
    
    private void GeneratePermutations(int[] nums, int start, List<IList<int>> result)
    {
        if (start == nums.Length - 1)
        {
            result.Add(nums.ToList());
            return;
        }

        for (var i = start; i < nums.Length; i++)
        {
            // swap the current element with the start element
            (nums[i], nums[start]) = (nums[start], nums[i]);
            
            // recursive call to generate permutations for the rest of the array
            GeneratePermutations(nums, start + 1, result);
            
            // backtracking, restore the array to its original state after the recursive call
            (nums[i], nums[start]) = (nums[start], nums[i]); 
        }
    }
}
