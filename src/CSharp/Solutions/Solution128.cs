namespace LeetCode.Solutions;

public class Solution128
{
    /// <summary>
    /// 128. Longest Consecutive Sequence
    /// <a href="https://leetcode.com/problems/longest-consecutive-sequence">See the problem</a>
    /// </summary>
    public int LongestConsecutive(int[] nums)
    {
        var set = new HashSet<int>(nums);
        var longest = 0;
        
        foreach (var num in nums)
        {
            if (!set.Contains(num - 1))
            {
                var currentNum = num;
                var currentStreak = 1;
                
                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentStreak++;
                }
                
                longest = Math.Max(longest, currentStreak);
            }
        }
        
        return longest;
    }
}
