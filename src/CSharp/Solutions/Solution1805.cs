using System.Text;

namespace LeetCode.Solutions;

public class Solution1805
{
    /// <summary>
    /// 1805. Number of Different Integers in a String - Easy
    /// <a href="https://leetcode.com/problems/number-of-different-integers-in-a-string">See the problem</a>
    /// </summary>
    public int NumDifferentIntegers(string word)
    {
        var set = new HashSet<string>();
        int n = word.Length;
        int i = 0;

        while (i < n)
        {
            if (char.IsDigit(word[i]))
            {
                int j = i;
                while (j < n && char.IsDigit(word[j])) j++;
                string num = word.Substring(i, j - i);

                // remove leading zeros
                int k = 0;
                while (k < num.Length && num[k] == '0') k++;
                string normalized = (k == num.Length) ? "0" : num.Substring(k);

                set.Add(normalized);
                i = j;
            }
            else
            {
                i++;
            }
        }

        return set.Count;
    }
}

