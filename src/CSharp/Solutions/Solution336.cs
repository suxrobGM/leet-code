namespace LeetCode.Solutions;

public class Solution336
{
    /// <summary>
    /// 336. Palindrome Pairs - Hard
    /// <a href="https://leetcode.com/problems/palindrome-pairs">See the problem</a>
    /// </summary>
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        var result = new List<IList<int>>();
        var wordIndex = new Dictionary<string, int>();

        for (var i = 0; i < words.Length; i++)
        {
            wordIndex[words[i]] = i;
        }

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];

            for (var j = 0; j <= word.Length; j++)
            {
                var left = word.Substring(0, j);
                var right = word.Substring(j);

                if (IsPalindrome(left))
                {
                    var reversedRight = new string(right.Reverse().ToArray());

                    if (wordIndex.ContainsKey(reversedRight) && wordIndex[reversedRight] != i)
                    {
                        result.Add([wordIndex[reversedRight], i]);
                    }
                }

                if (IsPalindrome(right) && right.Length > 0)
                {
                    var reversedLeft = new string(left.Reverse().ToArray());

                    if (wordIndex.ContainsKey(reversedLeft) && wordIndex[reversedLeft] != i)
                    {
                        result.Add([i, wordIndex[reversedLeft]]);
                    }
                }
            }
        }

        return result;
    }

    private bool IsPalindrome(string word)
    {
        var left = 0;
        var right = word.Length - 1;

        while (left < right)
        {
            if (word[left++] != word[right--])
            {
                return false;
            }
        }

        return true;
    }
}
