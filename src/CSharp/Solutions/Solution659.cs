using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution659
{
    /// <summary>
    /// 659. Split Array into Consecutive Subsequences - Medium
    /// <a href="https://leetcode.com/problems/split-array-into-consecutive-subsequences">See the problem</a>
    /// </summary>
    public bool IsPossible(int[] nums)
    {
        var freq = new Dictionary<int, int>();
        var appendFreq = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            freq[num] = freq.GetValueOrDefault(num, 0) + 1;
        }

        foreach (var num in nums)
        {
            if (freq[num] == 0)
            {
                continue;
            }

            if (appendFreq.GetValueOrDefault(num, 0) > 0)
            {
                appendFreq[num]--;
                appendFreq[num + 1] = appendFreq.GetValueOrDefault(num + 1, 0) + 1;
            }
            else if (freq.GetValueOrDefault(num + 1, 0) > 0 && freq.GetValueOrDefault(num + 2, 0) > 0)
            {
                freq[num + 1]--;
                freq[num + 2]--;
                appendFreq[num + 3] = appendFreq.GetValueOrDefault(num + 3, 0) + 1;
            }
            else
            {
                return false;
            }

            freq[num]--;
        }

        return true;
    }
}
