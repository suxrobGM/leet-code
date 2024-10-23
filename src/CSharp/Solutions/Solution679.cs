using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution679
{
    /// <summary>
    /// 679. 24 Game - Hard
    /// <a href="https://leetcode.com/problems/24-game">See the problem</a>
    /// </summary>
    public bool JudgePoint24(int[] cards)
    {
        var nums = new List<double>(cards.Length);
        foreach (var card in cards)
        {
            nums.Add(card);
        }
        return Solve(nums);
    }

    private bool Solve(List<double> nums)
    {
        if (nums.Count == 1)
        {
            return Math.Abs(nums[0] - 24.0) < 1e-6; // Check if the result is close enough to 24
        }

        // Try all pairs of numbers and apply all operators
        for (var i = 0; i < nums.Count; i++)
        {
            for (var j = 0; j < nums.Count; j++)
            {
                if (i != j)
                {
                    var next = new List<double>();
                    for (var k = 0; k < nums.Count; k++)
                    {
                        if (k != i && k != j)
                        {
                            next.Add(nums[k]);
                        }
                    }

                    foreach (var result in Compute(nums[i], nums[j]))
                    {
                        next.Add(result);
                        if (Solve(next))
                        {
                            return true;
                        }
                        next.RemoveAt(next.Count - 1);
                    }
                }
            }
        }
        return false;
    }

    // Compute all results from applying the operators to two numbers
    private List<double> Compute(double a, double b)
    {
        List<double> results = [a + b, a - b, b - a, a * b];
        if (Math.Abs(b) > 1e-6)
        {
            results.Add(a / b);
        }
        if (Math.Abs(a) > 1e-6)
        {
            results.Add(b / a);
        }
        return results;
    }
}
