namespace LeetCode.Solutions;

public class Solution384
{
    /// <summary>
    /// 384. Shuffle an Array - Medium
    /// <a href="https://leetcode.com/problems/shuffle-an-array">See the problem</a>
    /// </summary>
    public class Solution
    {
        private readonly int[] _original;
        private int[] _shuffled;
        private readonly Random _random;

        public Solution(int[] nums)
        {
            _original = nums;
            _shuffled = new int[nums.Length];
            Array.Copy(nums, _shuffled, nums.Length);
            _random = new Random();
        }

        public int[] Reset()
        {
            Array.Copy(_original, _shuffled, _original.Length);
            return _original;
        }

        public int[] Shuffle()
        {
            for (var i = 0; i < _shuffled.Length; i++)
            {
                var randomIndex = _random.Next(i, _shuffled.Length);
                (_shuffled[randomIndex], _shuffled[i]) = (_shuffled[i], _shuffled[randomIndex]);
            }

            return _shuffled;
        }
    }
}
