namespace LeetCode.Solutions;

public class Solution2059
{
    /// <summary>
    /// 2059. Minimum Operations to Convert Number - Medium
    /// <a href="https://leetcode.com/problems/minimum-operations-to-convert-number">See the problem</a>
    /// </summary>
    public int MinimumOperations(int[] nums, int start, int goal)
    {
        var visited = new bool[1001];
        var queue = new Queue<(int val, int steps)>();
        queue.Enqueue((start, 0));
        visited[start] = true;

        while (queue.Count > 0)
        {
            var (val, steps) = queue.Dequeue();

            foreach (var num in nums)
            {
                int[] next = [val + num, val - num, val ^ num];
                foreach (var nv in next)
                {
                    if (nv == goal) return steps + 1;
                    if (nv >= 0 && nv <= 1000 && !visited[nv])
                    {
                        visited[nv] = true;
                        queue.Enqueue((nv, steps + 1));
                    }
                }
            }
        }

        return -1;
    }
}
