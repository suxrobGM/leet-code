namespace LeetCode.Solutions;

public class Solution2085
{
    /// <summary>
    /// 2085. Count Common Words With One Occurrence - Easy
    /// <a href="https://leetcode.com/problems/count-common-words-with-one-occurrence">See the problem</a>
    /// </summary>
    public int CountWords(string[] words1, string[] words2)
    {
        var count1 = new Dictionary<string, int>();
        var count2 = new Dictionary<string, int>();

        foreach (var word in words1)
        {
            if (!count1.ContainsKey(word)) count1[word] = 0;
            count1[word]++;
        }

        foreach (var word in words2)
        {
            if (!count2.ContainsKey(word)) count2[word] = 0;
            count2[word]++;
        }

        var commonCount = 0;
        foreach (var kvp in count1)
        {
            if (kvp.Value == 1 && count2.TryGetValue(kvp.Key, out var c) && c == 1)
            {
                commonCount++;
            }
        }

        return commonCount;
    }
}
