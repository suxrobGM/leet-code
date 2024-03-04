namespace LeetCode.Solutions;

public class Solution228
{
    /// <summary>
    /// 228. Summary Ranges - Easy
    /// <a href="https://leetcode.com/problems/summary-ranges">See the problem</a>
    /// </summary>
    public IList<string> SummaryRanges(int[] nums)
    {
        var result = new List<string>();
        var i = 0;
        
        while (i < nums.Length)
        {
            var start = i;
            i++;
            while (i < nums.Length && nums[i] == nums[i - 1] + 1)
            {
                i++;
            }
            var end = i - 1;
            result.Add(start == end ? nums[start].ToString() : $"{nums[start]}->{nums[end]}");
        }
        
        return result;
    }
}
