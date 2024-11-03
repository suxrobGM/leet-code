using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution752
{
    /// <summary>
    /// 752. Open the Lock - Medium
    /// <a href="https://leetcode.com/problems/contain-virus">See the problem</a>
    /// </summary>
    public int OpenLock(string[] deadends, string target)
    {
        var deadendSet = new HashSet<string>(deadends);
        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        var steps = 0;

        queue.Enqueue("0000");
        visited.Add("0000");

        while (queue.Count > 0)
        {
            var size = queue.Count;

            for (var i = 0; i < size; i++)
            {
                var current = queue.Dequeue();

                if (deadendSet.Contains(current)) continue;

                if (current == target) return steps;

                for (var j = 0; j < 4; j++)
                {
                    var up = PlusOne(current, j);
                    if (!visited.Contains(up))
                    {
                        queue.Enqueue(up);
                        visited.Add(up);
                    }

                    var down = MinusOne(current, j);
                    if (!visited.Contains(down))
                    {
                        queue.Enqueue(down);
                        visited.Add(down);
                    }
                }
            }

            steps++;
        }

        return -1;
    }

    private string PlusOne(string s, int j)
    {
        var ch = s.ToCharArray();
        if (ch[j] == '9')
        {
            ch[j] = '0';
        }
        else
        {
            ch[j]++;
        }

        return new string(ch);
    }

    private string MinusOne(string s, int j)
    {
        var ch = s.ToCharArray();
        if (ch[j] == '0')
        {
            ch[j] = '9';
        }
        else
        {
            ch[j]--;
        }

        return new string(ch);
    }
}
