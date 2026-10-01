using System.Text;

namespace LeetCode.Solutions;

public class Solution2299
{
    /// <summary>
    /// 2299. Strong Password Checker II - Easy
    /// <a href="https://leetcode.com/problems/strong-password-checker-ii">See the problem</a>
    /// </summary>
    public bool StrongPasswordCheckerII(string password)
    {
        if (password.Length < 8)
        {
            return false;
        }

        var hasLower = false;
        var hasUpper = false;
        var hasDigit = false;
        var hasSpecial = false;

        for (var i = 0; i < password.Length; i++)
        {
            var c = password[i];

            if (i > 0 && c == password[i - 1])
            {
                return false;
            }

            if (char.IsLower(c))
            {
                hasLower = true;
            }
            else if (char.IsUpper(c))
            {
                hasUpper = true;
            }
            else if (char.IsDigit(c))
            {
                hasDigit = true;
            }
            else if ("!@#$%^&*()-+".Contains(c))
            {
                hasSpecial = true;
            }
        }

        return hasLower && hasUpper && hasDigit && hasSpecial;
    }
}
