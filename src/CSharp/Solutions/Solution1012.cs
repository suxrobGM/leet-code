using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1012
{
    /// <summary>
    /// 1012. Numbers With Repeated Digits - Hard
    /// <a href="https://leetcode.com/problems/numbers-with-repeated-digits</a>
    /// </summary>
    public int NumDupDigitsAtMostN(int n)
    {
        var digits = new List<int>();
        for (var i = n + 1; i > 0; i /= 10)
        {
            digits.Insert(0, i % 10);
        }

        var count = 0;
        var length = digits.Count;

        for (var i = 1; i < length; i++)
        {
            count += 9 * Permutation(9, i - 1);
        }

        var used = new bool[10];
        for (var i = 0; i < length; i++)
        {
            for (var j = i == 0 ? 1 : 0; j < digits[i]; j++)
            {
                if (!used[j])
                {
                    count += Permutation(9 - i, length - i - 1);
                }
            }

            if (used[digits[i]])
            {
                break;
            }

            used[digits[i]] = true;
        }

        return n - count;
    }

    private int Permutation(int n, int k)
    {
        var result = 1;
        for (var i = 0; i < k; i++)
        {
            result *= n - i;
        }

        return result;
    }
}
