using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution528
{
    /// <summary>
    /// 528. Random Pick with Weight - Medium
    /// <a href="https://leetcode.com/problems/random-pick-with-weight">See the problem</a>
    /// </summary>
    public class Solution
    {
        private readonly int[] _prefixSums;
        private readonly int _totalSum;

        public Solution(int[] w)
        {
            _prefixSums = new int[w.Length];
            _prefixSums[0] = w[0];
            for (int i = 1; i < w.Length; i++)
            {
                _prefixSums[i] = _prefixSums[i - 1] + w[i];
            }

            _totalSum = _prefixSums[^1];
        }

        public int PickIndex()
        {
            int target = new Random().Next(_totalSum) + 1;
            int left = 0;
            int right = _prefixSums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (_prefixSums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }
    }
}
