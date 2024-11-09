using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution784
{
    /// <summary>
    /// 784. Letter Case Permutation - Medium
    /// <a href="https://leetcode.com/problems/letter-case-permutation">See the problem</a>
    /// </summary>
    public IList<string> LetterCasePermutation(string s)
    {
        var result = new List<string>();
        var sb = new StringBuilder();
        LetterCasePermutation(s, 0, sb, result);
        return result;
    }

    private void LetterCasePermutation(string s, int index, StringBuilder sb, List<string> result)
    {
        if (index == s.Length)
        {
            result.Add(sb.ToString());
            return;
        }

        if (char.IsDigit(s[index]))
        {
            sb.Append(s[index]);
            LetterCasePermutation(s, index + 1, sb, result);
            sb.Remove(sb.Length - 1, 1);
        }
        else
        {
            sb.Append(char.ToLower(s[index]));
            LetterCasePermutation(s, index + 1, sb, result);
            sb.Remove(sb.Length - 1, 1);

            sb.Append(char.ToUpper(s[index]));
            LetterCasePermutation(s, index + 1, sb, result);
            sb.Remove(sb.Length - 1, 1);
        }
    }
}
