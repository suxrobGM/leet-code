using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution841
{
    /// <summary>
    /// 841. Keys and Rooms - Medium
    /// <a href="https://leetcode.com/problems/keys-and-rooms">See the problem</a>
    /// </summary>
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        var visited = new bool[rooms.Count];
        var stack = new Stack<int>();
        stack.Push(0);

        while (stack.Count > 0)
        {
            var room = stack.Pop();
            visited[room] = true;

            foreach (var key in rooms[room])
            {
                if (!visited[key])
                {
                    stack.Push(key);
                }
            }
        }

        return visited.All(v => v);
    }
}
