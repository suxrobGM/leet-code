namespace LeetCode.Solutions;

public class Solution2135
{
    /// <summary>
    /// 2135. Count Words Obtained After Adding a Letter - Medium
    /// <a href="https://leetcode.com/problems/count-words-obtained-after-adding-a-letter">See the problem</a>
    /// </summary>
    public int WordCount(string[] startWords, string[] targetWords)
    {
        HashSet<int> startMasks = [];

        foreach (string word in startWords)
        {
            startMasks.Add(GetMask(word));
        }

        int count = 0;
        foreach (string target in targetWords)
        {
            int mask = GetMask(target);

            foreach (char letter in target)
            {
                if (startMasks.Contains(mask ^ (1 << (letter - 'a'))))
                {
                    count++;
                    break;
                }
            }
        }

        return count;
    }

    private static int GetMask(string word)
    {
        int mask = 0;
        foreach (char letter in word)
        {
            mask |= 1 << (letter - 'a');
        }

        return mask;
    }
}
