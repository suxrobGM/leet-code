namespace LeetCode.Solutions;

public class Solution648
{
    /// <summary>
    /// 648. Replace Words - Medium
    /// <a href="https://leetcode.com/problems/replace-words">See the problem</a>
    /// </summary>
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        // Store roots in a set for fast lookups
        var rootSet = new HashSet<string>(dictionary);

        // Split the sentence into words
        var words = sentence.Split(' ');

        // Iterate over each word and replace it with the corresponding root
        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            string replacement = null;

            // Find the shortest root for the current word
            for (var j = 1; j <= word.Length; j++)
            {
                var prefix = word[..j];
                if (rootSet.Contains(prefix))
                {
                    replacement = prefix;
                    break;
                }
            }

            // If a root was found, replace the word
            if (replacement != null)
            {
                words[i] = replacement;
            }
        }

        // Join the words back into a sentence and return
        return string.Join(' ', words);
    }
}
