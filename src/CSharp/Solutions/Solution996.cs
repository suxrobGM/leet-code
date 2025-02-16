using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution996
{
    /// <summary>
    /// 996. Number of Squareful Arrays - Hard
    /// <a href="https://leetcode.com/problems/number-of-squareful-arrays">See the problem</a>
    /// </summary>
    public int NumSquarefulPerms(int[] nums)
    {
        var n = nums.Length;
        var count = new Dictionary<int, int>();
        var graph = new Dictionary<int, HashSet<int>>();
        var result = 0;

        foreach (var num in nums)
        {
            if (!count.ContainsKey(num))
            {
                count[num] = 0;
            }

            count[num]++;
        }

        foreach (var num1 in count.Keys)
        {
            graph[num1] = new HashSet<int>();

            foreach (var num2 in count.Keys)
            {
                var sqrt = (int)Math.Sqrt(num1 + num2);

                if (sqrt * sqrt == num1 + num2)
                {
                    graph[num1].Add(num2);
                }
            }
        }

        void Dfs(int num, int left)
        {
            count[num]--;

            if (left == 0)
            {
                result++;
            }
            else
            {
                foreach (var next in graph[num])
                {
                    if (count[next] > 0)
                    {
                        Dfs(next, left - 1);
                    }
                }
            }

            count[num]++;
        }

        foreach (var num in count.Keys)
        {
            Dfs(num, n - 1);
        }

        return result;
    }
}
