using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1233
{
    /// <summary>
    /// 1233. Remove Sub-Folders from the Filesystem - Medium
    /// <a href="https://leetcode.com/problems/remove-sub-folders-from-the-filesystem">See the problem</a>
    /// </summary>
    public IList<string> RemoveSubfolders(string[] folder)
    {
        Array.Sort(folder); // Step 1: Sort the folder paths

        var result = new List<string>();
        foreach (string path in folder)
        {
            if (result.Count == 0 || !path.StartsWith(result[^1] + "/"))
            {
                result.Add(path); // Only add if not subfolder of last added
            }
        }

        return result;
    }
}
