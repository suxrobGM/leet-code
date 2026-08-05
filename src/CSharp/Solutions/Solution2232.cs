namespace LeetCode.Solutions;

public class Solution2232
{
    /// <summary>
    /// 2232. Minimize Result by Adding Parentheses to Expression - Medium
    /// <a href="https://leetcode.com/problems/minimize-result-by-adding-parentheses-to-expression">See the problem</a>
    /// </summary>
    public string MinimizeResult(string expression)
    {
        var plusIndex = expression.IndexOf('+');
        var left = expression[..plusIndex];
        var right = expression[(plusIndex + 1)..];

        long best = long.MaxValue;
        var result = expression;

        // The expression is at most 10 characters, so brute force every valid pair of
        // positions: '(' goes somewhere inside the left operand, ')' inside the right one.
        for (var i = 0; i < left.Length; i++)
        {
            for (var j = 1; j <= right.Length; j++)
            {
                var prefix = left[..i];
                var suffix = right[j..];

                // An omitted multiplier means "no multiplication", i.e. a factor of 1.
                var value = (prefix.Length == 0 ? 1 : long.Parse(prefix))
                          * (long.Parse(left[i..]) + long.Parse(right[..j]))
                          * (suffix.Length == 0 ? 1 : long.Parse(suffix));

                if (value >= best)
                    continue;

                best = value;
                result = $"{prefix}({left[i..]}+{right[..j]}){suffix}";
            }
        }

        return result;
    }
}
