namespace LeetCode.Solutions;

public class Solution40
{
    /// <summary>
    /// 40. Combination Sum II - Medium
    /// <a href="https://leetcode.com/problems/combination-sum-ii">See the problem</a>
    /// </summary>
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        Array.Sort(candidates);
        CombinationSum(candidates, target, 0, new List<int>(), result);
        return result;
    }
    
    private void CombinationSum(int[] candidates, int target, int start, IList<int> current, IList<IList<int>> result)
    {
        if (target == 0)
        {
            result.Add(new List<int>(current));
            return;
        }
        
        for (var i = start; i < candidates.Length; i++)
        {
            if (i > start && candidates[i] == candidates[i - 1])
            {
                continue;
            }
            
            if (candidates[i] > target)
            {
                break;
            }
            
            current.Add(candidates[i]);
            CombinationSum(candidates, target - candidates[i], i + 1, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}
