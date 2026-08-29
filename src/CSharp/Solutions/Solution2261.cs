namespace LeetCode.Solutions;

public class Solution2261
{
    private sealed class TrieNode
    {
        public Dictionary<int, TrieNode> Children { get; } = [];
    }

    /// <summary>
    /// 2261. K Divisible Elements Subarrays - Medium
    /// <a href="https://leetcode.com/problems/k-divisible-elements-subarrays">See the problem</a>
    /// </summary>
    public int CountDistinct(int[] nums, int k, int p)
    {
        var root = new TrieNode();
        var distinctCount = 0;

        for (var start = 0; start < nums.Length; start++)
        {
            var node = root;
            var divisibleCount = 0;

            for (var end = start; end < nums.Length; end++)
            {
                if (nums[end] % p == 0)
                {
                    divisibleCount++;
                }

                if (divisibleCount > k)
                {
                    break;
                }

                if (!node.Children.TryGetValue(nums[end], out var child))
                {
                    child = new TrieNode();
                    node.Children[nums[end]] = child;
                    distinctCount++;
                }

                node = child;
            }
        }

        return distinctCount;
    }
}
