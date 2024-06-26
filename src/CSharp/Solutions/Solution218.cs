namespace LeetCode.Solutions;

public class Solution218
{
    /// <summary>
    /// 218. The Skyline Problem - Hard
    /// <a href="https://leetcode.com/problems/the-skyline-problem">See the problem</a>
    /// </summary>
    public IList<IList<int>> GetSkyline(int[][] buildings)
    {
        // Create a list of events
        var events = new List<(int x, int height, bool isStart)>();
        foreach (var building in buildings)
        {
            int left = building[0];
            int right = building[1];
            int height = building[2];
            events.Add((left, height, true));
            events.Add((right, height, false));
        }

        // Sort events: 
        // 1. by x-coordinate
        // 2. for the same x-coordinate, sort start event (-height) before end event (height)
        events.Sort((a, b) =>
            a.x != b.x ? a.x.CompareTo(b.x) : (a.isStart ? -a.height : a.height).CompareTo(b.isStart ? -b.height : b.height)
        );

        var result = new List<IList<int>>();
        var maxHeap = new SortedDictionary<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a))); // max-heap by using sorted dictionary
        maxHeap[0] = 1; // initial ground level

        int prevMaxHeight = 0;

        foreach (var (x, height, isStart) in events)
        {
            if (isStart)
            {
                if (!maxHeap.ContainsKey(height))
                {
                    maxHeap[height] = 0;
                }
                maxHeap[height]++;
            }
            else
            {
                if (maxHeap.ContainsKey(height))
                {
                    maxHeap[height]--;
                    if (maxHeap[height] == 0)
                    {
                        maxHeap.Remove(height);
                    }
                }
            }

            var currentMaxHeight = maxHeap.First().Key;
            if (currentMaxHeight != prevMaxHeight)
            {
                result.Add([x, currentMaxHeight]);
                prevMaxHeight = currentMaxHeight;
            }
        }

        return result;
    }
}
