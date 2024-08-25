namespace LeetCode.Solutions;

public class Solution500
{
    /// <summary>
    /// 500. Keyboard Row - Easy
    /// <a href="https://leetcode.com/problems/keyboard-row">See the problem</a>
    /// </summary>
    public string[] FindWords(string[] words)
    {
        string[] rows = ["qwertyuiop", "asdfghjkl", "zxcvbnm"];
        List<string> result = [];

        foreach (string word in words)
        {
            string lowerWord = word.ToLower();
            int row = -1;
            bool isSameRow = true;

            foreach (char letter in lowerWord)
            {
                if (row == -1)
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        if (rows[i].Contains(letter))
                        {
                            row = i;
                            break;
                        }
                    }
                }
                else if (!rows[row].Contains(letter))
                {
                    isSameRow = false;
                    break;
                }
            }

            if (isSameRow)
            {
                result.Add(word);
            }
        }

        return result.ToArray();
    }
}
