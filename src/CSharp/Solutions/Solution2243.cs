namespace LeetCode.Solutions;

public class Solution2243
{
    /// <summary>
    /// 2243. Calculate Digit Sum of a String - Easy
    /// <a href="https://leetcode.com/problems/calculate-digit-sum-of-a-string">See the problem</a>
    /// </summary>
    public string DigitSum(string s, int k)
    {
        while (s.Length > k)
        {
            var newS = "";
            for (var i = 0; i < s.Length; i += k)
            {
                var group = s.Substring(i, Math.Min(k, s.Length - i));
                var sum = group.Sum(c => c - '0');
                newS += sum;
            }
            s = newS;
        }
        return s;
    }
}
