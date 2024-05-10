namespace LeetCode.Solutions;

public class Solution150
{
    /// <summary>
    /// 150. Evaluate Reverse Polish Notation - Medium
    /// <a href="https://leetcode.com/problems/evaluate-reverse-polish-notation">See the problem</a>
    /// </summary>
    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();
        
        foreach (var token in tokens)
        {
            if (int.TryParse(token, out var number))
            {
                stack.Push(number);
            }
            else
            {
                var operand2 = stack.Pop();
                var operand1 = stack.Pop();
                
                switch (token)
                {
                    case "+":
                        stack.Push(operand1 + operand2);
                        break;
                    case "-":
                        stack.Push(operand1 - operand2);
                        break;
                    case "*":
                        stack.Push(operand1 * operand2);
                        break;
                    case "/":
                        stack.Push(operand1 / operand2);
                        break;
                }
            }
        }
        
        return stack.Pop();
    }
}
