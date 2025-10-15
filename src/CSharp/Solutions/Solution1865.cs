using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1865
{
    /// <summary>
    /// 1865. Finding Pairs With a Certain Sum - Medium
    /// <a href="https://leetcode.com/problems/finding-pairs-with-a-certain-sum">See the problem</a>
    /// </summary>
    public class FindSumPairs
    {
        private readonly int[] nums1;
        private readonly int[] nums2;
        private readonly Dictionary<int, int> freqMap;

        public FindSumPairs(int[] nums1, int[] nums2)
        {
            this.nums1 = nums1;
            this.nums2 = nums2;
            freqMap = new Dictionary<int, int>();

            foreach (int num in nums2)
            {
                if (freqMap.ContainsKey(num))
                    freqMap[num]++;
                else
                    freqMap[num] = 1;
            }
        }

        public void Add(int index, int val)
        {
            int oldValue = nums2[index];
            int newValue = oldValue + val;

            // Update frequency map
            freqMap[oldValue]--;
            if (freqMap[oldValue] == 0)
                freqMap.Remove(oldValue);

            if (freqMap.ContainsKey(newValue))
                freqMap[newValue]++;
            else
                freqMap[newValue] = 1;

            // Update the value in nums2
            nums2[index] = newValue;
        }

        public int Count(int tot)
        {
            int count = 0;

            foreach (int num in nums1)
            {
                int complement = tot - num;
                if (freqMap.ContainsKey(complement))
                    count += freqMap[complement];
            }

            return count;
        }
    }
}
