namespace LeetCode.Solutions;

public class Solution2042
{
    /// <summary>
    /// 2042. Check if Numbers Are Ascending in a Sentence - Easy
    /// <a href="https://leetcode.com/problems/check-if-numbers-are-ascending-in-a-sentence">See the problem</a>
    /// </summary>
    public bool AreNumbersAscending(string s)
    {
        var prev = -1;
        foreach (var word in s.Split(' '))
        {
            if (char.IsDigit(word[0]))
            {
                var num = int.Parse(word);
                if (num <= prev)
                    return false;

                prev = num;
            }
        }

        return true;
    }
}
