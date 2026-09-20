namespace LeetCode.Solutions;

public class Solution2284
{
    /// <summary>
    /// 2284. Sender With Largest Word Count - Medium
    /// <a href="https://leetcode.com/problems/sender-with-largest-word-count">See the problem</a>
    /// </summary>
    public string LargestWordCount(string[] messages, string[] senders)
    {
        var wordCounts = new Dictionary<string, int>();

        for (var i = 0; i < messages.Length; i++)
        {
            var words = 1;

            foreach (var symbol in messages[i])
            {
                if (symbol == ' ')
                {
                    words++;
                }
            }

            wordCounts.TryGetValue(senders[i], out var total);
            wordCounts[senders[i]] = total + words;
        }

        var result = string.Empty;
        var maxWords = 0;

        foreach (var (sender, words) in wordCounts)
        {
            if (words > maxWords || (words == maxWords && string.CompareOrdinal(sender, result) > 0))
            {
                maxWords = words;
                result = sender;
            }
        }

        return result;
    }
}
