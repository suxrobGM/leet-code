namespace LeetCode.Solutions;

public class Solution2287
{
    /// <summary>
    /// 2287. Rearrange Characters to Make Target String - Easy
    /// <a href="https://leetcode.com/problems/rearrange-characters-to-make-target-string">See the problem</a>
    /// </summary>
    public int RearrangeCharacters(string s, string target)
    {
        var sCount = new int[26];
        var targetCount = new int[26];

        foreach (var c in s)
        {
            sCount[c - 'a']++;
        }

        foreach (var c in target)
        {
            targetCount[c - 'a']++;
        }

        var result = int.MaxValue;

        for (var i = 0; i < 26; i++)
        {
            if (targetCount[i] > 0)
            {
                result = Math.Min(result, sCount[i] / targetCount[i]);
            }
        }

        return result;
    }
}
