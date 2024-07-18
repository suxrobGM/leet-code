namespace LeetCode.Solutions;

public class Solution398
{
    /// <summary>
    /// 398. Random Pick Index - Medium
    /// <a href="https://leetcode.com/problems/random-pick-index">See the problem</a>
    /// </summary>
    public class Solution
    {
        private readonly int[] _nums;
        private readonly Random _random;

        public Solution(int[] nums)
        {
            _nums = nums;
            _random = new Random();
        }

        public int Pick(int target)
        {
            var count = 0;
            var result = -1;

            for (var i = 0; i < _nums.Length; i++)
            {
                if (_nums[i] != target)
                {
                    continue;
                }

                count++;

                if (_random.Next(count) == 0)
                {
                    result = i;
                }
            }

            return result;
        }
    }
}
