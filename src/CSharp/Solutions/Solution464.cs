using System.Text;

namespace LeetCode.Solutions;

public class Solution464
{
    /// <summary>
    /// 464. Can I Win - Medium
    /// <a href="https://leetcode.com/problems/can-i-win">See the problem</a>
    /// </summary>
    public bool CanIWin(int maxChoosableInteger, int desiredTotal)
    {
        if (maxChoosableInteger >= desiredTotal)
        {
            return true;
        }

        if (maxChoosableInteger * (maxChoosableInteger + 1) / 2 < desiredTotal)
        {
            return false;
        }

        var memo = new Dictionary<string, bool>();
        return CanIWin(maxChoosableInteger, desiredTotal, 0, memo);
    }

    private bool CanIWin(int maxChoosableInteger, int desiredTotal, int state, Dictionary<string, bool> memo)
    {
        if (desiredTotal <= 0)
        {
            return false;
        }

        if (memo.ContainsKey(state.ToString()))
        {
            return memo[state.ToString()];
        }

        for (var i = 0; i < maxChoosableInteger; i++)
        {
            var current = 1 << i;
            if ((state & current) == 0)
            {
                if (!CanIWin(maxChoosableInteger, desiredTotal - i - 1, state | current, memo))
                {
                    memo[state.ToString()] = true;
                    return true;
                }
            }
        }

        memo[state.ToString()] = false;
        return false;
    }
}
