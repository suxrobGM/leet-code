using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution901
{
    /// <summary>
    /// 901. Online Stock Span - Medium
    /// <a href="https://leetcode.com/problems/online-stock-span">See the problem</a>
    /// </summary>
    public class StockSpanner
    {
        private Stack<(int price, int span)> stack;

        public StockSpanner()
        {
            stack = new Stack<(int price, int span)>();
        }

        public int Next(int price)
        {
            int span = 1;

            // While the stack has elements and the current price is greater than or equal to the top price
            while (stack.Count > 0 && stack.Peek().price <= price)
            {
                span += stack.Pop().span; // Add the span of the popped element
            }

            // Push the current price and its span onto the stack
            stack.Push((price, span));

            return span;
        }
    }
}
