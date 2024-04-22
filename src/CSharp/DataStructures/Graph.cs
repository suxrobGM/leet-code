namespace LeetCode.DataStructures;

public class Graph<T> where T : notnull
{
    private readonly Dictionary<T, List<T>> _adjacentList = [];
    
    public void AddEdge(T a, T b)
    {
        if (!_adjacentList.ContainsKey(a))
        {
            _adjacentList[a] = [];
        }

        if (!_adjacentList.ContainsKey(b))
        {
            _adjacentList[b] = [];
        }
        
        _adjacentList[a].Add(b);
        _adjacentList[b].Add(a);
    }
    
    public Dictionary<T, int> GreedyColoring()
    {
        var colors = new Dictionary<T, int>();
        
        foreach (var vertex in _adjacentList.Keys)
        {
            colors[vertex] = -1;
        }

        var color = 0;
        
        foreach (var vertex in _adjacentList.Keys)
        {
            if (colors[vertex] == -1)
            {
                ColorVertex(vertex, colors, color++);
            }
        }

        return colors;
    }
    
    private void ColorVertex(T vertex, Dictionary<T, int> colors, int color)
    {
        colors[vertex] = color;

        // Check neighboring vertices and avoid using their colors
        foreach (var neighbor in _adjacentList[vertex])
        {
            if (colors[neighbor] == -1)
            {
                ColorVertex(neighbor, colors, color);
            }
        }
    }
}
