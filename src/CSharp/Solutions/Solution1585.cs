using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1585
{
    /// <summary>
    /// 1585. Check If String Is Transformable With Substring Sort Operations - Hard
    /// <a href="https://leetcode.com/problems/check-if-string-is-transformable-with-substring-sort-operations">See the problem</a>
    /// </summary>
    public bool IsTransformable(string s, string t)
    {
        var digitQueues = new Queue<int>[10];
        for (int i = 0; i < 10; i++)
        {
            digitQueues[i] = new Queue<int>();
        }

        for (int i = 0; i < s.Length; i++)
        {
            digitQueues[s[i] - '0'].Enqueue(i);
        }

        foreach (char c in t)
        {
            int d = c - '0';
            if (digitQueues[d].Count == 0) return false;

            int idx = digitQueues[d].Dequeue();

            // Check if any smaller digit exists before current index
            for (int smaller = 0; smaller < d; smaller++)
            {
                if (digitQueues[smaller].Count > 0 && digitQueues[smaller].Peek() < idx)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
