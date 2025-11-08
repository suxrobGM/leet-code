using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1896
{
    /// <summary>
    /// 1896. Minimum Cost to Change the Final Value of Expression - Hard
    /// <a href="https://leetcode.com/problems/minimum-cost-to-change-the-final-value-of-expression">See the problem</a>
    /// </summary>
    public int MinOperationsToFlip(string expression)
    {
        var vals = new Stack<Cost>();
        var ops = new Stack<char>();

        for (int i = 0; i < expression.Length; i++)
        {
            char ch = expression[i];
            if (ch == '0')
            {
                vals.Push(new Cost(0, 1));
                TryReduce(vals, ops);
            }
            else if (ch == '1')
            {
                vals.Push(new Cost(1, 0));
                TryReduce(vals, ops);
            }
            else if (ch == '(')
            {
                ops.Push(ch);
            }
            else if (ch == '&' || ch == '|')
            {
                ops.Push(ch);
            }
            else if (ch == ')')
            {
                // Reduce everything inside the parentheses
                while (ops.Count > 0 && ops.Peek() != '(')
                    ReduceOnce(vals, ops);
                ops.Pop(); // pop '('
                // After a group becomes a single value, we may continue reducing
                TryReduce(vals, ops);
            }
        }

        // Reduce any remaining operations
        while (ops.Count > 0)
            ReduceOnce(vals, ops);

        var finalCost = vals.Pop();
        // To change the final value, flip to the opposite result.
        // Exactly one of {Zero, One} is zero (the current value), so answer = max.
        return Math.Max(finalCost.Zero, finalCost.One);
    }

    private static void TryReduce(Stack<Cost> vals, Stack<char> ops)
    {
        // Left-to-right, no precedence: reduce while top op isn't '('
        while (ops.Count > 0 && ops.Peek() != '(' && vals.Count >= 2)
            ReduceOnce(vals, ops);
    }

    private static void ReduceOnce(Stack<Cost> vals, Stack<char> ops)
    {
        var right = vals.Pop();
        var left = vals.Pop();
        char op = ops.Pop();
        vals.Push(Combine(left, right, op));
    }

    private static Cost Combine(Cost L, Cost R, char op)
    {
        // No-flip costs under the given operator
        int zero_nf, one_nf;
        if (op == '&')
        {
            one_nf = L.One + R.One; // need both 1
            zero_nf = Math.Min(
                L.Zero + Math.Min(R.Zero, R.One), // left 0 (right anything)
                R.Zero + Math.Min(L.Zero, L.One)  // right 0 (left anything)
            );
        }
        else // op == '|'
        {
            zero_nf = L.Zero + R.Zero; // need both 0
            one_nf = Math.Min(
                L.One + Math.Min(R.Zero, R.One),  // left 1 (right anything)
                R.One + Math.Min(L.Zero, L.One)   // right 1 (left anything)
            );
        }

        // Flip operator (cost +1) and compute under the flipped operator
        int zero_flip, one_flip;
        if (op == '&') // flip to '|'
        {
            zero_flip = 1 + (L.Zero + R.Zero);
            one_flip = 1 + Math.Min(
                L.One + Math.Min(R.Zero, R.One),
                R.One + Math.Min(L.Zero, L.One)
            );
        }
        else // op == '|' -> flip to '&'
        {
            one_flip = 1 + (L.One + R.One);
            zero_flip = 1 + Math.Min(
                L.Zero + Math.Min(R.Zero, R.One),
                R.Zero + Math.Min(L.Zero, L.One)
            );
        }

        return new Cost(
            Math.Min(zero_nf, zero_flip),
            Math.Min(one_nf, one_flip)
        );
    }

    struct Cost
    {
        public int Zero, One; // min ops to make this subexpr = 0 / 1
        public Cost(int zero, int one) { Zero = zero; One = one; }
    }
}
