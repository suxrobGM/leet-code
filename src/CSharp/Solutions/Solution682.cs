namespace LeetCode.Solutions;

public class Solution682
{
    /// <summary>
    /// 682. Baseball Game - Easy
    /// <a href="https://leetcode.com/problems/baseball-game">See the problem</a>
    /// </summary>
    public int CalPoints(string[] operations)
    {
        var stack = new Stack<int>();

        foreach (var operation in operations)
        {
            if (operation == "+")
            {
                var top = stack.Pop();
                var newTop = top + stack.Peek();
                stack.Push(top);
                stack.Push(newTop);
            }
            else if (operation == "D")
            {
                stack.Push(2 * stack.Peek());
            }
            else if (operation == "C")
            {
                stack.Pop();
            }
            else
            {
                stack.Push(int.Parse(operation));
            }
        }

        return stack.Sum();
    }
}
