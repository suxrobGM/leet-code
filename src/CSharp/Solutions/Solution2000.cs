namespace LeetCode.Solutions;

public class Solution2000
{
    /// <summary>
    /// 2000. Reverse Prefix of Word - Easy
    /// <a href="https://leetcode.com/problems/reverse-prefix-of-word">See the problem</a>
    /// </summary>
    public string ReversePrefix(string word, char ch)
    {
        int n = word.Length;
        char[] chars = word.ToCharArray();
        int index = -1;

        // Find the first occurrence of 'ch'
        for (int i = 0; i < n; i++)
        {
            if (chars[i] == ch)
            {
                index = i;
                break;
            }
        }

        // If 'ch' is not found, return the original string
        if (index == -1) return word;

        // Reverse the prefix up to index
        int left = 0;
        int right = index;
        while (left < right)
        {
            char temp = chars[left];
            chars[left] = chars[right];
            chars[right] = temp;
            left++;
            right--;
        }

        return new string(chars);
    }
}
