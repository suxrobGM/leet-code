using System.Text;

namespace LeetCode.Solutions;

public class Solution1834
{
    /// <summary>
    /// 1834. Single-Threaded CPU - Medium
    /// <a href="https://leetcode.com/problems/single-threaded-cpu">See the problem</a>
    /// </summary>
    public int[] GetOrder(int[][] tasks)
    {
        int n = tasks.Length;
        var indexedTasks = new (int enqueueTime, int processingTime, int index)[n];
        for (int i = 0; i < n; i++)
        {
            indexedTasks[i] = (tasks[i][0], tasks[i][1], i);
        }

        Array.Sort(indexedTasks, (a, b) =>
            a.enqueueTime != b.enqueueTime ? a.enqueueTime.CompareTo(b.enqueueTime) :
            a.processingTime != b.processingTime ? a.processingTime.CompareTo(b.processingTime) :
            a.index.CompareTo(b.index));

        var result = new int[n];
        var pq = new SortedSet<(int processingTime, int index)>(Comparer<(int processingTime, int index)>.Create((a, b) =>
            a.processingTime != b.processingTime ? a.processingTime.CompareTo(b.processingTime) :
            a.index.CompareTo(b.index)));

        int time = 0;
        int taskIndex = 0;
        for (int i = 0; i < n; i++)
        {
            if (pq.Count == 0)
            {
                time = Math.Max(time, indexedTasks[taskIndex].enqueueTime);
            }

            while (taskIndex < n && indexedTasks[taskIndex].enqueueTime <= time)
            {
                pq.Add((indexedTasks[taskIndex].processingTime, indexedTasks[taskIndex].index));
                taskIndex++;
            }

            var nextTask = pq.Min;
            pq.Remove(nextTask);
            result[i] = nextTask.index;
            time += nextTask.processingTime;
        }

        return result;
    }
}
