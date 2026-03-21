namespace LeetCode.Solutions;

public class Solution2071
{
    /// <summary>
    /// 2071. Maximum Number of Tasks You Can Assign - Hard
    /// <a href="https://leetcode.com/problems/maximum-number-of-tasks-you-can-assign">See the problem</a>
    /// </summary>
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
    {
        Array.Sort(tasks);
        Array.Sort(workers);

        int lo = 0, hi = Math.Min(tasks.Length, workers.Length);
        while (lo < hi)
        {
            var mid = (lo + hi + 1) / 2;
            if (CanAssign(tasks, workers, pills, strength, mid))
                lo = mid;
            else
                hi = mid - 1;
        }

        return lo;
    }

    private static bool CanAssign(int[] tasks, int[] workers, int pills, int strength, int k)
    {
        var deque = new LinkedList<int>();
        var j = 0;
        var pillsLeft = pills;
        var wStart = workers.Length - k;

        for (var i = wStart; i < workers.Length; i++)
        {
            while (j < k && tasks[j] <= workers[i] + strength)
            {
                deque.AddLast(tasks[j]);
                j++;
            }

            if (deque.Count == 0) return false;

            if (deque.First!.Value <= workers[i])
                deque.RemoveFirst();
            else if (pillsLeft > 0)
            {
                pillsLeft--;
                deque.RemoveLast();
            }
            else
                return false;
        }

        return true;
    }
}
