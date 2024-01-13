namespace LeetCode.Solutions;

public class Solution22
{
    /// <summary>
    /// 22. Generate Parentheses
    /// <a href="https://leetcode.com/problems/generate-parentheses">See the problem</a>
    /// </summary>
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        var queue = new Queue<(string str, int open, int close)>();
        queue.Enqueue(("", 0, 0));

        while (queue.Count > 0)
        {
            var (str, open, close) = queue.Dequeue();
            if (str.Length == n * 2)
            {
                result.Add(str);
                continue;
            }

            if (open < n)
            {
                queue.Enqueue((str + "(", open + 1, close));
            }
            if (close < open)
            {
                queue.Enqueue((str + ")", open, close + 1));
            }
        }

        return result;
    }
}
