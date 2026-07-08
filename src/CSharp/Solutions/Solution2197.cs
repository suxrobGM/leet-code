namespace LeetCode.Solutions;

public class Solution2197
{
    /// <summary>
    /// 2197. Replace Non-Coprime Numbers in Array - Hard
    /// <a href="https://leetcode.com/problems/replace-non-coprime-numbers-in-array">See the problem</a>
    /// </summary>
    public IList<int> ReplaceNonCoprimes(int[] nums)
    {
        var stack = new List<int>();

        foreach (var num in nums)
        {
            var current = num;

            // Keep merging the top of the stack while it is non-coprime with the current value.
            while (stack.Count > 0)
            {
                var top = stack[^1];
                var gcd = Gcd(top, current);

                if (gcd == 1)
                {
                    break;
                }

                stack.RemoveAt(stack.Count - 1);
                // LCM without overflow: (top / gcd) * current.
                current = (int)((long)top / gcd * current);
            }

            stack.Add(current);
        }

        return stack;
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }
}
