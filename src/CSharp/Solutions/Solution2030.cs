namespace LeetCode.Solutions;

public class Solution2030
{
    /// <summary>
    /// 2030. Smallest K-Length Subsequence With Occurrences of a Letter - Hard
    /// <a href="https://leetcode.com/problems/smallest-k-length-subsequence-with-occurrences-of-a-letter">See the problem</a>
    /// </summary>
    public string SmallestSubsequence(string s, int k, char letter, int repetition)
    {
        var remaining = 0;
        foreach (var c in s)
            if (c == letter)
                remaining++;

        var stack = new Stack<char>();
        var letterInStack = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            while (stack.Count > 0 && stack.Peek() > c
                && stack.Count + s.Length - i > k
                && (stack.Peek() != letter || letterInStack + remaining > repetition))
            {
                if (stack.Pop() == letter)
                    letterInStack--;
            }

            if (stack.Count < k)
            {
                if (c == letter)
                {
                    stack.Push(c);
                    letterInStack++;
                }
                else if (k - stack.Count > repetition - letterInStack)
                {
                    stack.Push(c);
                }
            }

            if (c == letter)
                remaining--;
        }

        var result = new char[k];
        for (var i = k - 1; i >= 0; i--)
            result[i] = stack.Pop();

        return new string(result);
    }
}
