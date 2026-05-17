namespace LeetCode.Solutions;

public class Solution2138
{
    /// <summary>
    /// 2138. Divide a String Into Groups of Size k - Easy
    /// <a href="https://leetcode.com/problems/divide-a-string-into-groups-of-size-k">See the problem</a>
    /// </summary>
    public string[] DivideString(string s, int k, char fill)
    {
        int n = s.Length;
        int groupCount = (n + k - 1) / k; // Calculate the number of groups needed
        string[] result = new string[groupCount];

        for (int i = 0; i < groupCount; i++)
        {
            int startIndex = i * k;
            int endIndex = Math.Min(startIndex + k, n);
            string group = s.Substring(startIndex, endIndex - startIndex);

            // If the last group is shorter than k, pad it with the fill character
            if (group.Length < k)
            {
                group = group.PadRight(k, fill);
            }

            result[i] = group;
        }

        return result;
    }
}
