using System.Text;


namespace LeetCode.Solutions;

public class Solution1678
{
    /// <summary>
    /// 1678. Goal Parser Interpretation - Easy
    /// <a href="https://leetcode.com/problems/goal-parser-interpretation">See the problem</a>
    /// </summary>
    public string Interpret(string command)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < command.Length; i++)
        {
            if (command[i] == 'G')
            {
                sb.Append('G');
            }
            else if (command[i] == '(')
            {
                if (command[i + 1] == ')')
                {
                    sb.Append('o');
                    i++; // Skip the next character
                }
                else if (command[i + 1] == 'a')
                {
                    sb.Append("al");
                    i += 3; // Skip "al)"
                }
            }
        }
        return sb.ToString();
    }
}
