using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1860
{
    /// <summary>
    /// 1860. Incremental Memory Leak - Medium
    /// <a href="https://leetcode.com/problems/incremental-memory-leak">See the problem</a>
    /// </summary>
    public int[] MemLeak(int memory1, int memory2)
    {
        int time = 1;

        while (true)
        {
            if (memory1 >= memory2)
            {
                if (memory1 >= time)
                {
                    memory1 -= time;
                }
                else
                {
                    break;
                }
            }
            else
            {
                if (memory2 >= time)
                {
                    memory2 -= time;
                }
                else
                {
                    break;
                }
            }

            time++;
        }

        return new[] { time, memory1, memory2 };
    }
}
