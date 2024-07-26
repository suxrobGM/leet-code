using System.Text;

namespace LeetCode.Solutions;

public class Solution420
{
    /// <summary>
    /// 420. Strong Password Checker - Hard
    /// <a href="https://leetcode.com/problems/strong-password-checker">See the problem</a>
    /// </summary>
    public int StrongPasswordChecker(string password)
    {
        var missingTypes = 3;
        var lowerCase = false;
        var upperCase = false;
        var digit = false;
        var length = password.Length;

        for (var i = 0; i < length; i++)
        {
            if (!lowerCase && char.IsLower(password[i]))
            {
                lowerCase = true;
                missingTypes--;
            }
            else if (!upperCase && char.IsUpper(password[i]))
            {
                upperCase = true;
                missingTypes--;
            }
            else if (!digit && char.IsDigit(password[i]))
            {
                digit = true;
                missingTypes--;
            }
        }

        var change = 0;
        var one = 0;
        var two = 0;

        for (var i = 0; i < length; i++)
        {
            if (i < length - 2 && password[i] == password[i + 1] && password[i] == password[i + 2])
            {
                var j = i + 2;

                while (j < length && password[j] == password[i])
                {
                    j++;
                }

                var lengthOfSequence = j - i;

                if (lengthOfSequence % 3 == 0)
                {
                    one++;
                }
                else if (lengthOfSequence % 3 == 1)
                {
                    two++;
                }

                change += lengthOfSequence / 3;
                i = j - 1;
            }
        }

        if (length < 6)
        {
            return Math.Max(missingTypes, 6 - length);
        }
        else if (length <= 20)
        {
            return Math.Max(missingTypes, change);
        }
        else
        {
            var delete = length - 20;

            change -= Math.Min(delete, one);
            change -= Math.Min(Math.Max(delete - one, 0) / 2, two);
            change -= Math.Max(delete - one - 2 * two, 0) / 3;

            return delete + Math.Max(missingTypes, change);
        }
    }
}
