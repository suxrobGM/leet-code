using System.Globalization;

namespace LeetCode.Solutions;

public class Solution2288
{
    /// <summary>
    /// 2288. Apply Discount to Prices - Medium
    /// <a href="https://leetcode.com/problems/apply-discount-to-prices">See the problem</a>
    /// </summary>
    public string DiscountPrices(string sentence, int discount)
    {
        var words = sentence.Split(' ');

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];

            if (word.Length > 1 && word[0] == '$' &&
                long.TryParse(word.AsSpan(1), NumberStyles.None, CultureInfo.InvariantCulture, out var price))
            {
                var discountedPrice = price * (100 - discount) / 100m;
                words[i] = "$" + discountedPrice.ToString("F2", CultureInfo.InvariantCulture);
            }
        }

        return string.Join(" ", words);
    }
}
