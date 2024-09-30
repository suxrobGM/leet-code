namespace LeetCode.Solutions;

public class Solution591
{
    /// <summary>
    /// 591. Tag Validator - Hard
    /// <a href="https://leetcode.com/problems/tag-validator">See the problem</a>
    /// </summary>
    public bool IsValid(string code)
    {
        var stack = new Stack<string>();
        for (var i = 0; i < code.Length; i++)
        {
            if (i > 0 && !stack.Any())
            {
                return false;
            }
            if (code[i] == '<')
            {
                if (i + 1 < code.Length && code[i + 1] == '!')
                {
                    if (i + 8 < code.Length && code.Substring(i + 1, 8) == "![CDATA[")
                    {
                        var j = i + 9;
                        i = code.IndexOf("]]>", j);
                        if (i == -1)
                        {
                            return false;
                        }
                        continue;
                    }
                    return false;
                }
                if (i + 1 < code.Length && code[i + 1] == '/')
                {
                    var j = i + 2;
                    i = code.IndexOf('>', j);
                    if (i == -1)
                    {
                        return false;
                    }
                    var tag = code.Substring(j, i - j);
                    if (!stack.Any() || stack.Pop() != tag)
                    {
                        return false;
                    }
                    continue;
                }
                var k = i + 1;
                i = code.IndexOf('>', k);
                if (i == -1)
                {
                    return false;
                }
                var tag1 = code.Substring(k, i - k);
                if (tag1.Length < 1 || tag1.Length > 9)
                {
                    return false;
                }
                foreach (var ch in tag1)
                {
                    if (ch < 'A' || ch > 'Z')
                    {
                        return false;
                    }
                }
                stack.Push(tag1);
            }
        }
        return !stack.Any();
    }
}
