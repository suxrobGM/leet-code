namespace LeetCode.Solutions;

public class Solution407
{
    /// <summary>
    /// 407. Trapping Rain Water II - Hard
    /// <a href="https://leetcode.com/problems/trapping-rain-water-ii">See the problem</a>
    /// </summary>
    public int TrapRainWater(int[][] heightMap)
    {
        if (heightMap.Length == 0 || heightMap[0].Length == 0) 
        {
            return 0;
        }

        var m = heightMap.Length;
        var n = heightMap[0].Length;
        var visited = new bool[m, n];
        var pq = new PriorityQueue<Cell>();

        // Add all boundary cells to the priority queue and mark them as visited
        for (var i = 0; i < m; i++)
        {
            pq.Enqueue(new Cell(i, 0, heightMap[i][0]));
            pq.Enqueue(new Cell(i, n - 1, heightMap[i][n - 1]));
            visited[i, 0] = true;
            visited[i, n - 1] = true;
        }

        for (var j = 1; j < n - 1; j++)
        {
            pq.Enqueue(new Cell(0, j, heightMap[0][j]));
            pq.Enqueue(new Cell(m - 1, j, heightMap[m - 1][j]));
            visited[0, j] = true;
            visited[m - 1, j] = true;
        }

        int[] dirs = [-1, 0, 1, 0, -1];
        var waterVolume = 0;

        while (pq.Count > 0)
        {
            var cell = pq.Dequeue();
            for (var k = 0; k < 4; k++)
            {
                var x = cell.X + dirs[k];
                var y = cell.Y + dirs[k + 1];

                if (x < 0 || x >= m || y < 0 || y >= n || visited[x, y])
                {
                    continue;
                }

                visited[x, y] = true;
                waterVolume += Math.Max(0, cell.Height - heightMap[x][y]);
                pq.Enqueue(new Cell(x, y, Math.Max(cell.Height, heightMap[x][y])));
            }
        }

        return waterVolume;
    }

    public class Cell : IComparable<Cell>
    {
        public int X { get; }
        public int Y { get; }
        public int Height { get; }

        public Cell(int x, int y, int height)
        {
            X = x;
            Y = y;
            Height = height;
        }

        public int CompareTo(Cell other)
        {
            return Height - other.Height;
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> data = [];

        public void Enqueue(T item)
        {
            data.Add(item);
            var ci = data.Count - 1; // child index; start at end

            while (ci > 0)
            {
                var pi = (ci - 1) / 2; // parent index

                if (data[ci].CompareTo(data[pi]) >= 0) 
                {
                    break; // child item is larger than (or equal) parent so done
                }

                (data[pi], data[ci]) = (data[ci], data[pi]);
                ci = pi;
            }
        }

        public T Dequeue()
        {
            // Assumes pq is not empty; up to calling code
            var li = data.Count - 1; // last index (before removal)
            var frontItem = data[0];   // fetch the front
            data[0] = data[li];
            data.RemoveAt(li);

            --li; // last index (after removal)
            var pi = 0; // parent index. start at front of pq

            while (true)
            {
                var ci = pi * 2 + 1; // left child index of parent

                if (ci > li) 
                {
                    break;  // no children so done
                }

                var rc = ci + 1;     // right child

                if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a right child (rc <= li) and it is smaller
                {
                    ci = rc; // then use the right child instead of left
                } 

                if (data[pi].CompareTo(data[ci]) <= 0) // parent is smaller than (or equal to) smallest child so done
                {
                    break;
                } 
                (data[ci], data[pi]) = (data[pi], data[ci]);
                pi = ci;
            }

            return frontItem;
        }

        public int Count => data.Count;
    }
}
