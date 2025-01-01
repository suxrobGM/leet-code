using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution925
{
    /// <summary>
    /// 925. Long Pressed Name - Easy
    /// <a href="https://leetcode.com/problems/long-pressed-name">See the problem</a>
    /// </summary>
    public bool IsLongPressedName(string name, string typed)
    {
        int i = 0, j = 0;

        while (j < typed.Length)
        {
            if (i < name.Length && name[i] == typed[j])
            {
                i++;
                j++;
            }
            else if (j > 0 && typed[j] == typed[j - 1])
            {
                j++;
            }
            else
            {
                return false;
            }
        }

        return i == name.Length;
    }
}
