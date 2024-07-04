namespace LeetCode.Solutions;

public class Solution306
{
    /// <summary>
    /// 306. Additive Number - Medium
    /// <a href="https://leetcode.com/problems/additive-number">See the problem</a>
    /// </summary>
    public bool IsAdditiveNumber(string num) 
    {
        int n = num.Length;

        for (int i = 1; i <= n / 2; ++i)
        {
            for (int j = i + 1; j < n; ++j)
            {
                if (IsValid(i, j, num))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool IsValid(int i, int j, string num)
    {
        var n = num.Length;

        if (num[0] == '0' && i > 1) 
        {
            return false;
        }
        if (num[i] == '0' && j - i > 1)
        {
            return false;
        }

        var num1 = long.Parse(num.Substring(0, i));
        var num2 = long.Parse(num.Substring(i, j - i));

        string sum;
        for (var start = j; start < n; start += sum.Length)
        {
            num2 += num1;
            num1 = num2 - num1;
            sum = num2.ToString();

            if (!num.Substring(start).StartsWith(sum))
            {
                return false;
            }
        }
        return true;
    }
}
