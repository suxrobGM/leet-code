namespace LeetCode.Solutions;

public class Solution241
{
    /// <summary>
    /// 241. Different Ways to Add Parentheses - Medium
    /// <a href="https://leetcode.com/problems/different-ways-to-add-parentheses">See the problem</a>
    /// </summary>
    public IList<int> DiffWaysToCompute(string expression)
    {
        var result = new List<int>();

        for (var i = 0; i < expression.Length; i++)
        {
            var c = expression[i];

            if (c == '+' || c == '-' || c == '*')
            {
                var left = DiffWaysToCompute(expression.Substring(0, i));
                var right = DiffWaysToCompute(expression.Substring(i + 1));

                foreach (var l in left)
                {
                    foreach (var r in right)
                    {
                        result.Add(c switch
                        {
                            '+' => l + r,
                            '-' => l - r,
                            '*' => l * r,
                            _ => throw new InvalidOperationException()
                        });
                    }
                }
            }
        }

        if (result.Count == 0)
        {
            result.Add(int.Parse(expression));
        }

        return result;
    }
}
