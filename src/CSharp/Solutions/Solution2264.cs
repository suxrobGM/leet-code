namespace LeetCode.Solutions;

public class Solution2264
{
    /// <summary>
    /// 2264. Largest 3-Same-Digit Number in String - Easy
    /// <a href="https://leetcode.com/problems/largest-3-same-digit-number-in-string">See the problem</a>
    /// </summary>
    public string LargestGoodInteger(string num)
    {
        var largest = string.Empty;

        for (var i = 0; i <= num.Length - 3; i++)
        {
            if (num[i] != num[i + 1] || num[i] != num[i + 2])
            {
                continue;
            }

            if (largest.Length == 0 || num[i] > largest[0])
            {
                largest = num.Substring(i, 3);
            }
        }

        return largest;
    }
}
