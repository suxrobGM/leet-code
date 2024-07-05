namespace LeetCode.Solutions;

public class Solution318
{
    /// <summary>
    /// 318. Maximum Product of Word Lengths - Medium
    /// <a href="https://leetcode.com/problems/maximum-product-of-word-lengths">See the problem</a>
    /// </summary>
    public int MaxProduct(string[] words)
    {
        var n = words.Length;
        var masks = new int[n];
        for (var i = 0; i < n; i++)
        {
            var mask = 0;
            foreach (var ch in words[i])
            {
                mask |= 1 << (ch - 'a');
            }

            masks[i] = mask;
        }

        var maxProduct = 0;
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if ((masks[i] & masks[j]) == 0)
                {
                    maxProduct = Math.Max(maxProduct, words[i].Length * words[j].Length);
                }
            }
        }

        return maxProduct;
    }
}
