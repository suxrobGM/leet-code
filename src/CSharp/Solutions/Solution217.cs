namespace LeetCode.Solutions;

public class Solution217
{
    /// <summary>
    /// 217. Contains Duplicate - Easy
    /// <a href="https://leetcode.com/problems/contains-duplicate">See the problem</a>
    /// </summary>
    public bool ContainsDuplicate(int[] nums) 
    {
        var set = new HashSet<int>();
        
        foreach (var num in nums)
        {
            if (!set.Add(num))
            {
                return true;
            }
        }
        
        return false;
    }
}
