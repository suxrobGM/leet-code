using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1467
{
    private int[] _balls;
    private int _k;                 // #colours
    private int _half;              // n = total / 2
    private double[] _fact;         // factorials

    private double _goodWays;       // numerator
    private double _allWays;        // denominator

    /// <summary>
    /// 1467. Probability of a Two Boxes Having The Same Number of Distinct Balls - Hard
    /// <a href="https://leetcode.com/problems/probability-of-a-two-boxes-having-the-same-number-of-distinct-balls">See the problem</a>
    /// </summary>
    public double GetProbability(int[] balls)
    {
        _balls = balls;
        _k = balls.Length;
        _half = balls.Sum() / 2;

        PrecomputeFactorials(balls.Sum());

        _goodWays = 0.0;
        _allWays = 0.0;

        Dfs(0, 0, 0, 0, 1.0);       // start search
        return _goodWays / _allWays;
    }

    /* depth-first enumeration of all vectors x */
    private void Dfs(int idx,
                     int usedInA,
                     int distinctA,
                     int distinctB,
                     double prodFact)          // Π x[c]! · Π y[c]!
    {
        if (idx == _k)
        {
            if (usedInA == _half)
            {
                double ways = _fact[_half] * _fact[_half] / prodFact;
                _allWays += ways;
                if (distinctA == distinctB)
                    _goodWays += ways;
            }
            return;
        }

        int colourCount = _balls[idx];
        int maxTake = Math.Min(colourCount, _half - usedInA);

        for (int take = 0; take <= maxTake; ++take)
        {
            int left = colourCount - take;

            int newDistinctA = distinctA + (take > 0 ? 1 : 0);
            int newDistinctB = distinctB + (left > 0 ? 1 : 0);

            double newProd = prodFact * _fact[take] * _fact[left];

            Dfs(idx + 1,
                usedInA + take,
                newDistinctA,
                newDistinctB,
                newProd);
        }
    }

    /* factorials up to n (n ≤ 48) */
    private void PrecomputeFactorials(int n)
    {
        _fact = new double[n + 1];
        _fact[0] = 1.0;
        for (int i = 1; i <= n; ++i)
            _fact[i] = _fact[i - 1] * i;
    }
}
