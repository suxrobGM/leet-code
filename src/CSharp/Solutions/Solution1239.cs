using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1239
{
    /// <summary>
    /// 1239. Maximum Length of a Concatenated String with Unique Characters - Medium
    /// <a href="https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters">See the problem</a>
    /// </summary>
    public int MaxLength(IList<string> arr)
    {
        int maxLength = 0;
        var uniqueStrings = new HashSet<string>
        {
            // Start with an empty string
            string.Empty
        };

        foreach (var str in arr)
        {
            var newUniqueStrings = new HashSet<string>(uniqueStrings);

            foreach (var existingStr in uniqueStrings)
            {
                var combinedStr = existingStr + str;

                if (IsUnique(combinedStr))
                {
                    newUniqueStrings.Add(combinedStr);
                    maxLength = Math.Max(maxLength, combinedStr.Length);
                }
            }

            uniqueStrings = newUniqueStrings;
        }

        return maxLength;
    }

    private bool IsUnique(string str)
    {
        var charSet = new HashSet<char>();

        foreach (var ch in str)
        {
            if (charSet.Contains(ch))
                return false;

            charSet.Add(ch);
        }

        return true;
    }
}
