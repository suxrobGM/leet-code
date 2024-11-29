using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution853
{
    /// <summary>
    /// 854. K-Similar Strings - Hard
    /// <a href="https://leetcode.com/problems/k-similar-strings">See the problem</a>
    /// </summary>
    public int KSimilarity(string s1, string s2)
    {
        if (s1 == s2)
        {
            return 0;
        }

        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        queue.Enqueue(s1);
        visited.Add(s1);

        var k = 0;
        while (queue.Count > 0)
        {
            var size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var current = queue.Dequeue();
                if (current == s2)
                {
                    return k;
                }

                var j = 0;
                while (current[j] == s2[j])
                {
                    j++;
                }

                for (int l = j + 1; l < s1.Length; l++)
                {
                    if (current[l] == s2[l] || current[l] != s2[j])
                    {
                        continue;
                    }

                    var next = Swap(current, j, l);
                    if (visited.Add(next))
                    {
                        queue.Enqueue(next);
                    }
                }
            }

            k++;
        }

        return -1;
    }

    private string Swap(string s, int i, int j)
    {
        var sb = new StringBuilder(s);
        sb[i] = s[j];
        sb[j] = s[i];
        return sb.ToString();
    }
}
