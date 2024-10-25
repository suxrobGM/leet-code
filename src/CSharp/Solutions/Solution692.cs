using System.Text;

namespace LeetCode.Solutions;

public class Solution692
{
    /// <summary>
    /// 692. Top K Frequent Words - Medium
    /// <a href="https://leetcode.com/problems/top-k-frequent-words">See the problem</a>
    /// </summary>
    public IList<string> TopKFrequent(string[] words, int k)
    {
        var frequencyMap = new Dictionary<string, int>();
        foreach (var word in words)
        {
            frequencyMap[word] = frequencyMap.GetValueOrDefault(word, 0) + 1;
        }

        var sortedWords = frequencyMap.Keys.ToList();
        sortedWords.Sort((a, b) =>
        {
            var frequencyComparison = frequencyMap[b].CompareTo(frequencyMap[a]);
            if (frequencyComparison == 0)
            {
                return a.CompareTo(b);
            }

            return frequencyComparison;
        });

        return sortedWords.Take(k).ToList();
    }
}
