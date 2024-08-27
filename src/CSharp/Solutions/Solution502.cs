namespace LeetCode.Solutions;

public class Solution502
{
    /// <summary>
    /// 502. IPO - Hard
    /// <a href="https://leetcode.com/problems/ipo">See the problem</a>
    /// </summary>
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        int n = profits.Length;
        // Step 1: Create a list of projects and sort them by capital required
        List<(int capital, int profit)> projects = [];
        for (int i = 0; i < n; i++)
        {
            projects.Add((capital[i], profits[i]));
        }
        projects.Sort((a, b) => a.capital.CompareTo(b.capital));

        // Step 2: Use a max heap to store the profits of the projects we can afford
        PriorityQueue<int, int> maxHeap = new(Comparer<int>.Create((a, b) => b - a));
        int projectIndex = 0;

        // Step 3: Repeat up to k times to maximize the capital
        for (int i = 0; i < k; i++)
        {
            // Add all projects that we can start with the current capital to the max heap
            while (projectIndex < n && projects[projectIndex].capital <= w)
            {
                maxHeap.Enqueue(projects[projectIndex].profit, projects[projectIndex].profit);
                projectIndex++;
            }

            // If we can't start any more projects, break out
            if (maxHeap.Count == 0)
            {
                break;
            }

            // Start the project with the maximum profit we can afford
            w += maxHeap.Dequeue();
        }

        return w;
    }
}
