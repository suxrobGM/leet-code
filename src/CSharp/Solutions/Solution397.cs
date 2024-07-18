namespace LeetCode.Solutions;

public class Solution397
{
    /// <summary>
    /// 397. Integer Replacement - Medium
    /// <a href="https://leetcode.com/problems/integer-replacement">See the problem</a>
    /// </summary>
    public int IntegerReplacement(int n)
    {
        // Use a queue to implement BFS
        var queue = new Queue<(long number, int steps)>();
        queue.Enqueue((n, 0));

        // Use a set to track visited numbers to avoid cycles
        var visited = new HashSet<long>
        {
            n
        };

        while (queue.Count > 0)
        {
            var (current, steps) = queue.Dequeue();

            // If we reach 1, return the number of steps
            if (current == 1)
            {
                return steps;
            }

            // For even numbers, we can directly divide by 2
            if (current % 2 == 0)
            {
                var next = current / 2;
                if (!visited.Contains(next))
                {
                    visited.Add(next);
                    queue.Enqueue((next, steps + 1));
                }
            }
            else
            {
                // For odd numbers, we have two choices: add 1 or subtract 1
                var next1 = current + 1;
                if (!visited.Contains(next1))
                {
                    visited.Add(next1);
                    queue.Enqueue((next1, steps + 1));
                }

                var next2 = current - 1;
                if (!visited.Contains(next2))
                {
                    visited.Add(next2);
                    queue.Enqueue((next2, steps + 1));
                }
            }
        }

        // If we somehow exit the loop without finding 1, return -1 (shouldn't happen)
        return -1;
    }
}
