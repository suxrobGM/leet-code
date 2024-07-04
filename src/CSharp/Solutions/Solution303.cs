namespace LeetCode.Solutions;

public class Solution303
{
    /// <summary>
    /// 303. Range Sum Query - Immutable - Easy
    /// <a href="https://leetcode.com/problems/range-sum-query-immutable">See the problem</a>
    /// </summary>
    public class NumArray 
    {
        private readonly int[] _sums;

        public NumArray(int[] nums) 
        {
            _sums = new int[nums.Length + 1];
            for (var i = 0; i < nums.Length; i++)
            {
                _sums[i + 1] = _sums[i] + nums[i];
            }
        }

        public int SumRange(int left, int right) 
        {
            return _sums[right + 1] - _sums[left];
        }
    }
}
