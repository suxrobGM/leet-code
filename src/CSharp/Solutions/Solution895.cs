using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution895
{
    /// <summary>
    /// 895. Maximum Frequency Stack - Hard
    /// <a href="https://leetcode.com/problems/maximum-frequency-stack">See the problem</a>
    /// </summary>
    public class FreqStack
    {
        private readonly Dictionary<int, int> freq = []; // Frequency of elements
        private readonly Dictionary<int, Stack<int>> group = []; // Elements grouped by frequency
        private int maxFreq; // Maximum frequency

        public void Push(int val)
        {
            // Update frequency of the element
            if (!freq.ContainsKey(val))
            {
                freq[val] = 0;
            }
            freq[val]++;
            int f = freq[val];

            // Update the group for the new frequency
            if (!group.ContainsKey(f))
            {
                group[f] = new Stack<int>();
            }
            group[f].Push(val);

            // Update max frequency
            maxFreq = Math.Max(maxFreq, f);
        }

        public int Pop()
        {
            // Get the element from the max frequency group
            int val = group[maxFreq].Pop();

            // Decrement the frequency of the element
            freq[val]--;

            // If the max frequency group is empty, decrement maxFreq
            if (group[maxFreq].Count == 0)
            {
                maxFreq--;
            }

            return val;
        }
    }
}
