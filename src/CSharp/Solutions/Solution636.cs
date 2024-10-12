using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution636
{
    /// <summary>
    /// 636. Exclusive Time of Functions - Medium
    /// <a href="https://leetcode.com/problems/exclusive-time-of-functions">See the problem</a>
    /// </summary>
    public int[] ExclusiveTime(int n, IList<string> logs)
    {
        var result = new int[n]; // Array to store exclusive time for each function
        var stack = new Stack<int>(); // Stack to track function calls
        var prevTime = 0; // Previous timestamp

        foreach (var log in logs)
        {
            // Split the log into parts
            var parts = log.Split(':');
            var functionId = int.Parse(parts[0]);
            var action = parts[1];
            var timestamp = int.Parse(parts[2]);

            if (action == "start")
            {
                if (stack.Count > 0)
                {
                    // Add time to the function at the top of the stack (current running function)
                    result[stack.Peek()] += timestamp - prevTime;
                }
                // Push the current function onto the stack and update prevTime
                stack.Push(functionId);
                prevTime = timestamp;
            }
            else
            { // action == "end"
                // Pop the function from the stack (current function has ended)
                result[stack.Pop()] += timestamp - prevTime + 1;
                // Update prevTime to the next timestamp (one unit after this function ended)
                prevTime = timestamp + 1;
            }
        }

        return result;
    }
}
