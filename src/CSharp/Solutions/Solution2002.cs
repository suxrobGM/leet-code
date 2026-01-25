namespace LeetCode.Solutions;

public class Solution2002
{
    /// <summary>
    /// 2002. Maximum Product of the Length of Two Palindromic Subsequences - Medium
    /// <a href="https://leetcode.com/problems/maximum-product-of-the-length-of-two-palindromic-subsequences">See the problem</a>
    /// </summary>
    public int MaxProduct(string s)
    {
        int n = s.Length;
        int maxProduct = 0;

        // Generate all possible subsequences using bitmasking
        for (int mask1 = 1; mask1 < (1 << n); mask1++)
        {
            string subseq1 = GetSubsequence(s, mask1);
            if (IsPalindrome(subseq1))
            {
                for (int mask2 = 1; mask2 < (1 << n); mask2++)
                {
                    // Ensure subseq2 does not share characters with subseq1
                    if ((mask1 & mask2) == 0)
                    {
                        string subseq2 = GetSubsequence(s, mask2);
                        if (IsPalindrome(subseq2))
                        {
                            int product = subseq1.Length * subseq2.Length;
                            maxProduct = Math.Max(maxProduct, product);
                        }
                    }
                }
            }
        }

        return maxProduct;
    }

    private string GetSubsequence(string s, int mask)
    {
        var subseq = new System.Text.StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if ((mask & (1 << i)) != 0)
            {
                subseq.Append(s[i]);
            }
        }
        return subseq.ToString();
    }

    private bool IsPalindrome(string str)
    {
        int left = 0;
        int right = str.Length - 1;
        while (left < right)
        {
            if (str[left] != str[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}
