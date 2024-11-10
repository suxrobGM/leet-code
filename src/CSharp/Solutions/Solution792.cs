
namespace LeetCode.Solutions;

public class Solution792
{
    /// <summary>
    /// 792. Number of Matching Subsequences - Medium
    /// <a href="https://leetcode.com/problems/number-of-matching-subsequences">See the problem</a>
    /// </summary>
    public int NumMatchingSubseq(string s, string[] words)
    {
        var waiting = new Dictionary<char, Queue<string>>();

        // Initialize the dictionary with empty queues for each character
        foreach (char c in s)
        {
            if (!waiting.ContainsKey(c))
            {
                waiting[c] = new Queue<string>();
            }
        }

        // Add words to the corresponding queues based on their starting character
        foreach (var word in words)
        {
            if (waiting.ContainsKey(word[0]))
            {
                waiting[word[0]].Enqueue(word);
            }
            else
            {
                waiting[word[0]] = new Queue<string>();
                waiting[word[0]].Enqueue(word);
            }
        }

        int count = 0;

        // Iterate through the string s
        foreach (char c in s)
        {
            if (!waiting.ContainsKey(c)) continue;

            int size = waiting[c].Count;
            for (int i = 0; i < size; i++)
            {
                var word = waiting[c].Dequeue();
                if (word.Length == 1)
                {
                    count++;
                }
                else
                {
                    if (waiting.ContainsKey(word[1]))
                    {
                        waiting[word[1]].Enqueue(word.Substring(1));
                    }
                    else
                    {
                        waiting[word[1]] = new Queue<string>();
                        waiting[word[1]].Enqueue(word.Substring(1));
                    }
                }
            }
        }

        return count;
    }
}
