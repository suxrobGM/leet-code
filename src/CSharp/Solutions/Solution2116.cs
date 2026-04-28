namespace LeetCode.Solutions;

public class Solution2116
{
    /// <summary>
    /// 2116. Check if a Parentheses String Can Be Valid - Medium
    /// <a href="https://leetcode.com/problems/check-if-a-parentheses-string-can-be-valid">See the problem</a>
    /// </summary>
    public bool CanBeValid(string s, string locked)
    {
        if (s.Length % 2 != 0)
        {
            return false;
        }

        var balance = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (locked[i] == '0' || s[i] == '(')
            {
                balance++;
            }
            else
            {
                balance--;
            }

            if (balance < 0)
            {
                return false;
            }
        }

        balance = 0;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (locked[i] == '0' || s[i] == ')')
            {
                balance++;
            }
            else
            {
                balance--;
            }

            if (balance < 0)
            {
                return false;
            }
        }

        return true;
    }
}
