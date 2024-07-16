namespace LeetCode.Solutions;

public class Solution388
{
    /// <summary>
    /// 388. Longest Absolute File Path - Medium
    /// <a href="https://leetcode.com/problems/longest-absolute-file-path">See the problem</a>
    /// </summary>
    public int LengthLongestPath(string input)
    {
        var stack = new Stack<int>();
        stack.Push(0);

        var maxLength = 0;
        foreach (var line in input.Split('\n'))
        {
            var level = line.LastIndexOf('\t') + 1;
            while (stack.Count > level + 1)
            {
                stack.Pop();
            }

            var length = stack.Peek() + line.Length - level + 1;
            stack.Push(length);

            if (line.Contains('.'))
            {
                maxLength = Math.Max(maxLength, length - 1);
            }
        }

        return maxLength;
    }
}
