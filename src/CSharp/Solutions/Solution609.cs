using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution609
{
    /// <summary>
    /// 609. Find Duplicate File in System - Medium
    /// <a href="https://leetcode.com/problems/find-duplicate-file-in-system">See the problem</a>
    /// </summary>
    public IList<IList<string>> FindDuplicate(string[] paths)
    {
        var dict = new Dictionary<string, IList<string>>();
        foreach (var path in paths)
        {
            var parts = path.Split(' ');
            var directory = parts[0];

            for (var i = 1; i < parts.Length; i++)
            {
                var file = parts[i];
                var openBracketIndex = file.IndexOf('(');
                var closeBracketIndex = file.IndexOf(')');
                var content = file[(openBracketIndex + 1)..closeBracketIndex];
                var fileName = file[..openBracketIndex];

                if (!dict.ContainsKey(content))
                {
                    dict[content] = [];
                }

                dict[content].Add($"{directory}/{fileName}");
            }
        }
        
        return dict.Values.Where(x => x.Count > 1).Select(x => x).ToList();
    }
}
