namespace LeetCode.Solutions;

public class Solution307
{
    /// <summary>
    /// 307. Range Sum Query - Mutable - Medium
    /// <a href="https://leetcode.com/problems/range-sum-query-mutable">See the problem</a>
    /// </summary>
    public class NumArray 
    {
        private readonly int[] _nums;
        private readonly int[] _sums;
        private readonly int _n;

        public NumArray(int[] nums) 
        {
            _n = nums.Length;
            _nums = new int[_n];
            _sums = new int[_n + 1];

            for (var i = 0; i < _n; i++)
            {
                Update(i, nums[i]);
            }
        }

        public void Update(int index, int val) 
        {
            var diff = val - _nums[index];
            _nums[index] = val;

            for (var i = index + 1; i <= _n; i += i & -i)
            {
                _sums[i] += diff;
            }
        }

        public int SumRange(int left, int right) 
        {
            return GetSum(right + 1) - GetSum(left);
        }

        private int GetSum(int index)
        {
            var sum = 0;
            for (var i = index; i > 0; i -= i & -i)
            {
                sum += _sums[i];
            }
            return sum;
        }
    }
}
