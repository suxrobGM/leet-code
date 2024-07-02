namespace LeetCode.Solutions;

public class Solution282
{
    /// <summary>
    /// 282. Expression Add Operators - Hard
    /// <a href="https://leetcode.com/problems/expression-add-operators">See the problem</a>
    /// </summary>
    public IList<string> AddOperators(string num, int target)
    {
        var result = new List<string>();
        AddOperators(num, target, 0, 0, 0, "", result);
        return result;
    }

    private void AddOperators(string num, int target, int index, long current, long previous, string expression, IList<string> result)
    {
        if (index == num.Length)
        {
            if (current == target)
            {
                result.Add(expression);
            }

            return;
        }

        for (var i = index; i < num.Length; i++)
        {
            if (i > index && num[index] == '0')
            {
                break;
            }

            var value = long.Parse(num[index..(i + 1)]);
            if (index == 0)
            {
                AddOperators(num, target, i + 1, value, value, value.ToString(), result);
            }
            else
            {
                AddOperators(num, target, i + 1, current + value, value, $"{expression}+{value}", result);
                AddOperators(num, target, i + 1, current - value, -value, $"{expression}-{value}", result);
                AddOperators(num, target, i + 1, current - previous + previous * value, previous * value, $"{expression}*{value}", result);
            }
        }
    }
}
