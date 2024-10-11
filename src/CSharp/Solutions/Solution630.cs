using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution630
{
    /// <summary>
    /// 630. Course Schedule III - Hard
    /// <a href="https://leetcode.com/problems/course-schedule-iii">See the problem</a>
    /// </summary>
    public int ScheduleCourse(int[][] courses)
    {
        // Sort courses by their lastDay (second value of each pair)
        Array.Sort(courses, (a, b) => a[1] - b[1]);

        // Max heap (priority queue) to store course durations we've taken
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        var totalTime = 0;

        // Iterate over each course
        foreach (var course in courses)
        {
            var duration = course[0];
            var lastDay = course[1];

            // If we can take this course within its allowed time, take it
            if (totalTime + duration <= lastDay)
            {
                totalTime += duration;
                maxHeap.Enqueue(duration, duration); // Add the course duration to the max heap
            }
            else if (maxHeap.Count > 0 && maxHeap.Peek() > duration)
            {
                // If we can't take it, but it's shorter than the longest course we've taken
                // Remove the longest duration course and replace it with this one
                totalTime -= maxHeap.Dequeue(); // Remove the largest duration course
                totalTime += duration; // Add the current course duration
                maxHeap.Enqueue(duration, duration); // Update heap with the new course
            }
        }

        // The number of courses we can take is the size of the heap
        return maxHeap.Count;
    }
}
