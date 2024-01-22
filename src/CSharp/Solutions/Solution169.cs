namespace LeetCode.Solutions;

public class Solution169
{
    /// <summary>
    /// 169. Majority Element
    /// <a href="https://leetcode.com/problems/majority-element">See the problem</a>
    /// </summary>
    public int MajorityElement(int[] nums)
    {
        var frequencies = new Dictionary<int, int>();
        
        foreach (var num in nums)
        {
            if (!frequencies.TryAdd(num, 1))
            {
                frequencies[num]++;
            }
        }

        var majorityElement = frequencies.MaxBy(pair => pair.Value).Key;
        return majorityElement;
    }
}
