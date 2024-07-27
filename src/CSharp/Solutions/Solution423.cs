using System.Text;

namespace LeetCode.Solutions;

public class Solution423
{
    /// <summary>
    /// 423. Reconstruct Original Digits from English - Medium
    /// <a href="https://leetcode.com/problems/reconstruct-original-digits-from-english">See the problem</a>
    /// </summary>
    public string OriginalDigits(string s)
    {
        var count = new int[26];
        foreach (var c in s)
        {
            count[c - 'a']++;
        }

        var digits = new int[10];
        digits[0] = count['z' - 'a'];
        digits[2] = count['w' - 'a'];
        digits[4] = count['u' - 'a'];
        digits[6] = count['x' - 'a'];
        digits[8] = count['g' - 'a'];
        digits[3] = count['h' - 'a'] - digits[8];
        digits[5] = count['f' - 'a'] - digits[4];
        digits[7] = count['s' - 'a'] - digits[6];
        digits[9] = count['i' - 'a'] - digits[5] - digits[6] - digits[8];
        digits[1] = count['o' - 'a'] - digits[0] - digits[2] - digits[4];

        var result = new StringBuilder();
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < digits[i]; j++)
            {
                result.Append(i);
            }
        }

        return result.ToString();
    }
}
