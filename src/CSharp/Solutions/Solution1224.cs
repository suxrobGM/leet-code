using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1224
{
    /// <summary>
    /// 1224. Maximum Equal Frequency - Hard
    /// <a href="https://leetcode.com/problems/maximum-equal-frequency">See the problem</a>
    /// </summary>
    public int MaxEqualFreq(int[] nums)
    {
        var count = new Dictionary<int, int>();
        var freq = new Dictionary<int, int>();
        int res = 0, maxFreq = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];

            // Remove from old frequency
            if (count.ContainsKey(num))
            {
                int oldFreq = count[num];
                freq[oldFreq]--;
                if (freq[oldFreq] == 0) freq.Remove(oldFreq);
                count[num]++;
            }
            else
            {
                count[num] = 1;
            }

            // Add to new frequency
            int newFreq = count[num];
            if (!freq.ContainsKey(newFreq))
                freq[newFreq] = 0;
            freq[newFreq]++;

            maxFreq = Math.Max(maxFreq, newFreq);

            int total = i + 1;

            bool case1 = (maxFreq == 1);
            bool case2 = (freq.ContainsKey(1) && freq[1] == 1 && freq.Count == 2 && freq[maxFreq] * maxFreq + 1 == total);
            bool case3 = (freq.ContainsKey(maxFreq) && freq[maxFreq] == 1 &&
                         freq.ContainsKey(maxFreq - 1) &&
                         freq[maxFreq - 1] * (maxFreq - 1) + maxFreq == total);

            if (case1 || case2 || case3)
                res = total;
        }

        return res;
    }
}
