using System.Text;


namespace LeetCode.Solutions;

public class Solution1694
{
    /// <summary>
    /// 1694. Reformat Phone Number - Easy
    /// <a href="https://leetcode.com/problems/reformat-phone-number">See the problem</a>
    /// </summary>
    public string ReformatNumber(string number)
    {
        // Step 1: Remove all spaces and dashes
        var digits = new string(number.Where(char.IsDigit).ToArray());
        var result = new List<string>();
        int i = 0;

        while (digits.Length - i > 4)
        {
            result.Add(digits.Substring(i, 3));
            i += 3;
        }

        int remaining = digits.Length - i;

        if (remaining == 4)
        {
            result.Add(digits.Substring(i, 2));
            result.Add(digits.Substring(i + 2, 2));
        }
        else
        {
            result.Add(digits.Substring(i, remaining));
        }

        return string.Join("-", result);
    }
}


