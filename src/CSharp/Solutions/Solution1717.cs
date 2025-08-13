using System.Text;


namespace LeetCode.Solutions;

public class Solution1717
{
    /// <summary>
    /// 1717. Maximum Score From Removing Substrings - Medium
    /// <a href="https://leetcode.com/problems/maximum-score-from-removing-substrings">See the problem</a>
    /// </summary>
    public int MaximumGain(string s, int x, int y)
    {
        long score = 0;

        if (x >= y)
        {
            s = RemovePairs(s, 'a', 'b', x, ref score); // remove "ab" first
            RemovePairs(s, 'b', 'a', y, ref score);     // then remove "ba"
        }
        else
        {
            s = RemovePairs(s, 'b', 'a', y, ref score); // remove "ba" first
            RemovePairs(s, 'a', 'b', x, ref score);     // then remove "ab"
        }

        return (int)score;
    }

    private string RemovePairs(string s, char first, char second, int value, ref long score)
    {
        var st = new StringBuilder();
        foreach (char c in s)
        {
            if (st.Length > 0 && st[st.Length - 1] == first && c == second)
            {
                st.Length--;      // pop first
                score += value;   // gained by removing "firstsecond"
            }
            else
            {
                st.Append(c);
            }
        }
        return st.ToString();
    }
}
