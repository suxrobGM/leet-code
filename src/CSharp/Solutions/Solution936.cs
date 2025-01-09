using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution936
{
    /// <summary>
    /// 936. Stamping The Sequence - Hard
    /// <a href="https://leetcode.com/problems/stamping-the-sequence">See the problem</a>
    /// </summary>
    public int[] MovesToStamp(string stamp, string target)
    {
        var stampChars = stamp.ToCharArray();
        var targetChars = target.ToCharArray();
        var result = new List<int>();

        bool Replace(int start)
        {
            bool replaced = false;
            for (int i = 0; i < stampChars.Length; i++)
            {
                if (targetChars[start + i] == '?')
                {
                    continue;
                }

                if (targetChars[start + i] != stampChars[i])
                {
                    return false;
                }

                replaced = true;
            }

            if (replaced)
            {
                for (int i = 0; i < stampChars.Length; i++)
                {
                    targetChars[start + i] = '?';
                }

                result.Add(start);
            }

            return replaced;
        }

        bool stamped;
        do
        {
            stamped = false;
            for (int i = 0; i <= targetChars.Length - stampChars.Length; i++)
            {
                stamped |= Replace(i);
            }
        } while (stamped);

        for (int i = 0; i < targetChars.Length; i++)
        {
            if (targetChars[i] != '?')
            {
                return Array.Empty<int>();
            }
        }

        result.Reverse();
        return [.. result];
    }
}
