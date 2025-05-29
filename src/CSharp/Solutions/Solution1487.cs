using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1487
{
    /// <summary>
    /// 1487. Making File Names Unique - Medium
    /// <a href="https://leetcode.com/problems/making-file-names-unique">See the problem</a>
    /// </summary>
    public string[] GetFolderNames(string[] names)
    {
        var nameCount = new Dictionary<string, int>();
        var result = new string[names.Length];

        for (int i = 0; i < names.Length; i++)
        {
            string name = names[i];
            if (!nameCount.ContainsKey(name))
            {
                nameCount[name] = 0;
                result[i] = name;
            }
            else
            {
                int count = ++nameCount[name];
                while (nameCount.ContainsKey($"{name}({count})"))
                {
                    count++;
                }
                nameCount[$"{name}({count})"] = 0;
                result[i] = $"{name}({count})";
            }
        }

        return result;
    }
}
